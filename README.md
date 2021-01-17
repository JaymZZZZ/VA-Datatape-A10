# VA-Datatape for DCS A-10 Warthog and Tank Killer II
Voice Attack Datatape for the DCS A-10

## Installation
All you need to do to use it is:

1) download the .vab file and import it into Voice Attack. If you already have a voice attack profile, you can either import this into that profile or you can import it as a separate profile and link them. (VoiceAttack README explains how to do this - https://voiceattack.com/howto.aspx)
2) Create a coordinate file in one of the following locations (example file included in repo)
  * C:\Users\YOUR_USER\Saved Games\DCS.Openbeta\Datatape\A10_datatape.txt
  * C:\Users\YOUR_USER\Saved Games\DCS\Datatape\A10_datatape.txt
  * C:\Program Files (x86)\VoiceAttack\Datatape\A10_datatape.txt

3) If you are already using an existing profile. Configure your existing profile to include the DataTape profile by:
 * Click "Edit Profile" (Alt + E) on your existing profile
 * Next to the profile name, click on "Options"

4) Use one of the two voice commands:
  * "Load Datatape" - loads all steerpoints in the file
  * "Load Datatape waypoint X" - loads only steerpoint X from the file
  * In the popup window, click the "..." button next to "Include Commands from other Profiles"
  * In the next popup, click the plus sign
  * Select the "Datatype (A-10) vX.X.X" profile
  * Click OK on all pop up windows
  * Click "Apply" in the bottom right of the options window
  
 5) In DCS, there are a few buttons you need to remap
  * CDU WP KEY = L Ctrl + L Shift + W
  * CDU LSK L3 = L Ctrl + L Shift + 3
  * CDU LSK L5 = L Ctrl + L Shift + 5
  * CDU LSK L7 = L Ctrl + L Shift + 7
  * CDU LSK L9 = L Ctrl + L Shift + 9
  * CDU LSK R3 = L Ctrl + L Shift + 4 
  * CDU LSK R5 = L Ctrl + L Shift + 6
  * CDU LSK R7 = L Ctrl + L Shift + 8
  * CDU LSK R9 = L Ctrl + L Shift + 0
  * CDU CLR  = L Ctrl + L Shift + \
 
  
## Notes
* inline.vb file listed here is for informational purposes to show you the inner workings of the script. When you import the .vab file, the inline file is pre-loaded. 
* This profiles only works for the F-16C Viper at this time. More aircraft can be added, time permitting. 
* **This profile can cause conflict with heavily modified profiles and will almost certainly have issues if you have remapped your CDU buttons to use anything other than the defaults**


## Credits/Shoutouts:
* This module was inspired by "DCS F-16C Viper VoiceAttack by Bailey v2.0.0" found at https://www.digitalcombatsimulator.com/en/files/3306505/


## License 
Apache 2.0 License (do what you want with it, just make sure to give me and Bailey credit)

