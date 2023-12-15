import cv2
import numpy as np
import mss
import time
import zmq

# Define the size of the screen
screen_width, screen_height = 1920, 1080  # Replace with the actual dimensions of your screen

# Calculate coordinates for the center of the screen
center_x = screen_width // 2
center_y = screen_height // 2

# Define the size of the region of interest (ROI) as 20% of the screen
roi_width = 50
roi_height = int(screen_height * 0.2)

# Adjust the coordinates to shift the ROI to the left and up
left = center_x - roi_width // 2 + 300  # Shift left by 50 pixels
top = center_y - roi_height // 2 - 50  # Shift up by 50 pixels
right = left + roi_width
bottom = top + roi_height

# Initialize a previous frame
prev_frame = None

context = zmq.Context()
socket = context.socket(zmq.REP)
socket.bind("tcp://*:5555")

with mss.mss() as sct:
    while True:
        # Capture the screen in the adjusted ROI
        screenshot = sct.grab({"mon": 1, "left": left, "top": top, "width": roi_width, "height": roi_height})
        current_frame = np.array(screenshot)
        userInput = ""
        # Convert to grayscale
        current_frame_gray = cv2.cvtColor(current_frame, cv2.COLOR_BGR2GRAY)

        if prev_frame is not None:
            # Calculate the absolute difference between current and previous frames
            frame_diff = cv2.absdiff(current_frame_gray, prev_frame)

            # Set a threshold for change detection
            threshold = 100
            change_detected = (frame_diff > threshold).any()
            userInput = "Acelerar" if change_detected else "Frenar"
            if userInput == "Acelerar":
                socket.send(b"Acelerar")
            else:
                socket.send(b"Frenar")

            # Write the result to a text file
            with open("output.txt", "w") as file:
                file.write(userInput)

            # Save the image of the shifted region being analyzed
            cv2.imwrite("detected_region.png", current_frame)

        message = socket.recv()
        
        prev_frame = current_frame_gray

        # You may need to add a delay to control the frame capture rate
        time.sleep(0.05)
