# LOLRAT: Lightweight, Stealthy, and Memory-Resident Remote Access Trojan

**Disclaimer: This project is for educational and research purposes only. Any unauthorized use of this software for malicious activities is strictly prohibited. The authors and contributors of LOLRAT do not endorse or support illegal activities. Use this tool responsibly and ethically.**

## Introduction

LOLRAT is a fully undetected Remote Access Trojan (RAT) designed to operate entirely in memory without leaving traces on the target system's disk. The name "LOLRAT" humorously emphasizes the project's focus on staying concealed and living only in the land of memory, ensuring stealthiness and minimizing the risk of detection.

The primary goal of this project is to create a remote access tool that operates covertly in a target system's memory and establishes encrypted communication channels between the Command and Control (C2) server and the client.

## Features

- **In-Memory Execution:** LOLRAT is designed to execute its code entirely in memory, making it extremely difficult to detect by traditional antivirus and anti-malware solutions.

- **Stealthy Persistence:** Achieving persistence without writing any files to disk is a critical concern in maintaining the Trojan's stealthiness. LOLRAT achieves this by using registry keys to execute a command on system startup, typically something like `cmd /c "python -c <Malicious code here>"`.

- **Modular Execution:** LOLRAT divides its functionality into separate modules to prevent code size from exceeding the maximum character limit in Windows Command Prompt (8191 characters). Each module is designed to be small and efficient, facilitating ease of use and customization.

## How It Works

1. Executes python script in memory (using "python -c "Content-Here"") that connects to C2.
2. 

## Getting Started

To get started with LOLRAT, follow these steps:

1. Clone this repository to your local machine.
2. Customize and configure the LOLRAT modules to meet your specific needs.
3. Establish a secure Command and Control (C2) server for communication with the LOLRAT client.
4. Compile and encrypt your customized modules.
5. Deploy the client on the target system.
6. Begin communicating with the client through the C2 server.

**Please use LOLRAT responsibly and only for legitimate, authorized purposes. Unauthorized use or any malicious activities are strictly prohibited and may have legal consequences.**

## Contribution

Contributions to LOLRAT are welcome. If you have any ideas for improvements or new features, please submit a pull request or open an issue.

## License

LOLRAT is licensed under the [MIT License](LICENSE), which allows you to use, modify, and distribute the software as long as you follow the terms and conditions of the license.

## Disclaimer

This project is for educational and research purposes only. The author and contributors of LOLRAT do not endorse or support any illegal activities or the misuse of this software. Use LOLRAT responsibly and ethically, following all applicable laws and regulations.

**Stay stealthy, stay ethical!**
