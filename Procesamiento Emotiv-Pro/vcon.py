#
#   Hello World client in Python
#   Connects REQ socket to tcp://localhost:5555
#   Sends "Hello" to server, expects "World" back
#

import zmq
import vgamepad as vg

pad = vg.VX360Gamepad()

context = zmq.Context()

#  Socket to talk to server
print("Connecting to hello world server…")
socket = context.socket(zmq.REQ)
socket.connect("tcp://192.168.103.100:5555")
request=1
#  Do 10 requests, waiting each time for a response
countA = 0
countF = 0
while True:
    print(f"Sending request {request} …")
    socket.send(b"Hello")
    #  Get the reply.
    message = socket.recv()
    print(f"Received reply {request} [ {message} ]")
    if message == b'Acelerar':
        countA += 1
        countF -= 1
        pad.right_trigger(value = min(countA,255))
        pad.left_trigger(value = min(countF,0))
        
    elif message == b'Frenar':
        countA -= 1
        countF += 1
        pad.right_trigger(value = min(countA,0))
        pad.left_trigger(value = min(countF, 255))
        
    File = open("direction.txt","r")
    b = File.read()
    a=0
    if len(b)>0:
        a = float(b)
    pad.left_joystick_float(x_value_float=a, y_value_float = 0.0)
    pad.update()
    
