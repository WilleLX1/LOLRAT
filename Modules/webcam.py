import cv2
import numpy as np
import socket
import sys

# Extract IP and PORT from command line arguments
if len(sys.argv) != 3:
    print('Usage: file.py <IP> <PORT>')
    sys.exit(1)

server_ip = sys.argv[1]
server_port = int(sys.argv[2])

# Initialize the webcam
cap = cv2.VideoCapture(0)

# Create a socket for the TCP connection
client_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
client_socket.connect((server_ip, server_port))

try:
    while True:
        # Capture a frame from the webcam
        ret, frame = cap.read()
        
        # Encode the image as JPEG
        _, img_encoded = cv2.imencode('.jpg', frame)

        # Convert the image to bytes
        img_bytes = img_encoded.tobytes()

        # Send the image to the server
        client_socket.sendall(len(img_bytes).to_bytes(4, byteorder='big'))
        client_socket.sendall(img_bytes)

        # Break the loop if you want to take only one picture
        break

finally:
    # Release the webcam and close the socket
    cap.release()
    client_socket.close()