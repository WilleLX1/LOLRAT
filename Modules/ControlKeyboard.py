import sys
import pyautogui

def press_key(key):
    pyautogui.press(key)

if __name__ == '__main__':
    if len(sys.argv) != 2:
        sys.exit(1)

    input_key = sys.argv[1]

    press_key(input_key)
