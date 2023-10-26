import socket
import pyautogui
from PIL import ImageGrab
import io
import struct
import time
import logging
import sys

# Initialize the logger
logging.basicConfig(level=logging.INFO)
logger = logging.getLogger(__name__)

def capture_screenshot():
    logger.info("Capturing screenshot...")
    screenshot = pyautogui.screenshot()  # Capture a screenshot
    logger.info("Screenshot captured")
    return screenshot

def create_image_stream(screenshot):
    logger.info("Creating image stream...")
    image_stream = io.BytesIO()  # Create a bytes buffer to hold the screenshot
    logger.info("Image stream created")

    logger.info("Saving screenshot to image stream...")
    # Save the screenshot to the bytes buffer in JPEG format
    screenshot.save(image_stream, format="JPEG")
    logger.info("Screenshot saved to image stream")

    return image_stream

def send_image(client_socket, image_stream):
    try:
        logger.info("Getting image size...")
        # Get the image size in bytes and convert it to a 4-byte packed format
        image_size = struct.pack('!I', image_stream.tell())
        logger.info("Image size: %d", image_stream.tell())

        logger.info("Sending image size to the receiver...")
        # Send the image size to the receiver
        client_socket.sendall(image_size)
        logger.info("Image size sent")

        logger.info("Rewinding the image stream...")
        # Rewind the bytes buffer to the beginning and send the screenshot
        image_stream.seek(0)
        logger.info("Image stream rewound")

        logger.info("Sending the screenshot to the receiver...")
        client_socket.sendall(image_stream.read())
        logger.info("Screenshot sent")
    except Exception as e:
        logger.error("Error sending screenshot: %s", str(e))

def main(host, port):
    while True:
        client_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

        try:
            # Resolve DNS/domain to IP address
            host_ip = socket.gethostbyname(host)

            client_socket.connect((host_ip, port))
            logger.info("Connected to the receiver at %s:%d", host, port)

            screenshot = capture_screenshot()
            image_stream = create_image_stream(screenshot)
            send_image(client_socket, image_stream)
        except ConnectionRefusedError:
            logger.error("Connection to the receiver failed. Make sure the receiver is listening.")
        except socket.gaierror:
            logger.error("Error resolving host: %s", host)
        finally:
            client_socket.close()
        time.sleep(2)

if __name__ == "__main__":
    if len(sys.argv) != 3:
        print("Usage: python your_script.py <host> <port>")
        sys.exit(1)

    host = sys.argv[1]
    port = int(sys.argv[2])

    main(host, port)
