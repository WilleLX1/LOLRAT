import socket
import pyautogui
from PIL import ImageGrab
import io
import struct
import time
import ctypes
import logging
import sys

# Initialize the logger
logging.basicConfig(level=logging.INFO)
logger = logging.getLogger(__name__)

def capture_screenshot():
    screenshot = pyautogui.screenshot()  # Capture a screenshot
    return screenshot

def create_image_stream(screenshot):
    image_stream = io.BytesIO()  # Create a bytes buffer to hold the screenshot

    # Save the screenshot to the bytes buffer in JPEG format
    screenshot.save(image_stream, format='JPEG')

    return image_stream

def send_image(client_socket, image_stream):
    try:
        # Get the image size in bytes and convert it to a 4-byte packed format
        image_size = struct.pack('!I', image_stream.tell())

        # Send the image size to the receiver
        client_socket.sendall(image_size)

        # Rewind the bytes buffer to the beginning and send the screenshot
        image_stream.seek(0)

        client_socket.sendall(image_stream.read())
    except Exception as e:
        logger.error('Error sending screenshot: %s', str(e))

def main(host, port):
    while True:
        client_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
        try:
            # Resolve DNS/domain to IP address
            host_ip = socket.gethostbyname(host)

            client_socket.connect((host_ip, port))

            screenshot = capture_screenshot()
            image_stream = create_image_stream(screenshot)
            send_image(client_socket, image_stream)
        except ConnectionRefusedError:
            logger.error('Connection to the receiver failed. Make sure the receiver is listening.')
        except socket.gaierror:
            logger.error('Error resolving host: %s', host)
        finally:
            client_socket.close()
        time.sleep(2)

if __name__ == '__main__':
    if len(sys.argv) != 3:
        print('Usage: python your_script.py <host> <port>')
        sys.exit(1)

    # Set the console window title
    ctypes.windll.kernel32.SetConsoleTitleW("ComBoom")

    host = sys.argv[1]
    port = int(sys.argv[2])

    main(host, port)
