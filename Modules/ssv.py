import socket
import io
from PIL import Image, ImageTk
import tkinter as tk
import threading

# Constants
HOST = '0.0.0.0'  # Listen on all available network interfaces
PORT = 1234  # Replace with the port you want to use

# Global variables to store the image and PhotoImage
image = None
image_tk = None

def receive_image(label):
    server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    server_socket.bind((HOST, PORT))
    server_socket.listen(1)

    print("Waiting for a connection...")

    while True:
        client_socket, client_address = server_socket.accept()
        print(f"Accepted connection from {client_address}")

        image_size = client_socket.recv(4)
        if not image_size:
            print("No data received.")
            continue

        image_size = int.from_bytes(image_size, byteorder='big')
        print("Receiving image of size:", image_size)

        image_data = b''
        while len(image_data) < image_size:
            chunk = client_socket.recv(image_size - len(image_data))
            if not chunk:
                print("Connection closed before receiving the entire image.")
                break
            image_data += chunk

        image_stream = io.BytesIO(image_data)
        img = Image.open(image_stream)

        # Update the global image and create a PhotoImage
        global image, image_tk
        image = img
        image_tk = ImageTk.PhotoImage(img)

        # Call resize_image to resize the image after receiving
        resize_image(None, label)

        client_socket.close()

def resize_image(event, label):
    if image is not None:
        window_width = label.winfo_width()
        window_height = label.winfo_height()

        # Resize the image to fit the label (window)
        scaled_image = image.resize((window_width, window_height), Image.LANCZOS)

        # Convert the scaled image to a PhotoImage object (required by Tkinter)
        global image_tk
        image_tk = ImageTk.PhotoImage(scaled_image)
        label.config(image=image_tk)  # Update the label with the new image

def update_image(label):
    if image_tk:
        label.config(image=image_tk)
    label.after(100, update_image, label)  # Schedule the update

def main():
    # Create a Tkinter window
    window = tk.Tk()
    window.title("Received Image")

    # Create a Label to display the image
    label = tk.Label(window)
    label.pack(fill=tk.BOTH, expand=tk.YES)

    # Start the image receiving thread
    image_thread = threading.Thread(target=receive_image, args=(label,))
    image_thread.daemon = True  # Allow the program to exit even if this thread is running
    image_thread.start()

    # Start the image updating function in the main thread
    update_image(label)

    # Bind the <Configure> event to the resize_image function
    label.bind('<Configure>', lambda event: resize_image(event, label))

    window.mainloop()

if __name__ == "__main__":
    main()