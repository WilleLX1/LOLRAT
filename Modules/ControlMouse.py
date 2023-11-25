import sys
import pyautogui
import time

def click_mouse(x, y, click_type):
    pyautogui.moveTo(x, y, duration=0)
    
    if click_type == 'left':
        pyautogui.click()
    elif click_type == 'double':
        pyautogui.doubleClick()
    elif click_type == 'right':
        pyautogui.rightClick()
    elif click_type == 'middle':
        pyautogui.middleClick()
    else:
        print('Invalid click type. Please use \'left\', \'double\', \'right\', or \'middle\'.')
        sys.exit(1)

if __name__ == '__main__':
    if len(sys.argv) != 4:
        print('Usage: python mouse.py x y click_type')
        sys.exit(1)

    try:
        x = int(sys.argv[1])
        y = int(sys.argv[2])
        click_type = sys.argv[3].lower()
    except ValueError:
        print('Invalid arguments. Please provide integers for x and y coordinates.')
        sys.exit(1)

    click_mouse(x, y, click_type)
