# Overview

Remote home application consist of client and server where the client remotely update server's database. Raspberry Pi is use as a server while client is mobile application compiled in Android and iOS package using Xamarin Forms. The flowchart shows how the entire system works.

Flowchart

# Server Set Up

1. Raspberry Pi set up with Raspbian OS.
2. Database server installation. Refer to the video by "Pi4IoT" below for this part.

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[![MySQL Part #1 - How to install MySQL on the new RASPBIAN STRETCH OS](https://img.youtube.com/vi/kQ0HoLva9Yc/0.jpg)](http://www.youtube.com/watch?v=kQ0HoLva9Yc&feature=youtu.be)

3. Run SQL script to create a table (KIV: will write later).
4. Drop RequestSwitchState.php and UpdateSwitchState.php to server root index directory. Ensure those scripts can be run using browser.
5. Drop HomeSwitchHandler.py in any directory. Run it using terminal. Terminal command >> sudo python HomeSwitchHandler.py

# Client Usage

Download the Android ad-hoc distribution and install it on your phone. Currently, iOS is not distribute publicly due to development's provisioning profile have limitation number of device. See the usage demo video below:

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[![Remote Home Client Mobile Application](https://img.youtube.com/vi/TixUWaTxB4Y/0.jpg)](https://www.youtube.com/watch?v=TixUWaTxB4Y&t=15s)

# Download
Download [Here](https://github.com/zaimpauzi/RemoteHomeMobileApp/releases)
