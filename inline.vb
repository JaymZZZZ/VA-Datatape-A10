
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Data
Imports System.Drawing
Imports System.Diagnostics
Imports System.Windows.Forms
Imports System.Linq
Imports System.Xml.Linq
Imports System.Threading.Tasks
Imports System.IO


Public Class VAInline


	Public Sub Main()
	
	Dim file_locations = {
	Environ$("USERPROFILE")+"\Saved Games\DCS.openbeta\Datatape\a10_datatape.txt", 
	Environ$("USERPROFILE")+"\Saved Games\DCS\Datatape\a10_datatape.txt", 
	"C:\Program Files (x86)\VoiceAttack\Datatape\a10_datatape.txt"
	}
	
	Dim file_found as Boolean = false
	Dim datatape_file as string
	Dim loc as integer = 0
	
	while file_found = false and loc < file_locations.length
		
		If File.Exists(file_locations(loc)) Then
			file_found = true
			datatape_file = file_locations(loc)
			VA.WriteToLog("Reading A-10 data from: "+datatape_file, "blue")
		end if
		loc = loc + 1
		
	end while
	
	if file_found = false then
		VA.WriteToLog(file_locations(2), "red")
		VA.WriteToLog(file_locations(1), "red")
		VA.WriteToLog(file_locations(0), "red")	
		VA.WriteToLog("In order for datatape to run, you need to create a datatape file in one of the following locations:", "red")	
		VA.WriteToLog("Could not locate data file: "+datatape_file, "red")
		return
	end if
		
	for each line as string in File.ReadLines(datatape_file)

		Dim rowdata As String() = line.Split(New Char() {":"c})

		If rowdata(0) <> "1" Then
		
			line = line.replace("	", " ").replace("     ", " ").replace("    ", " ").replace("   ", " ").replace("  ", " ")
			line = line.replace("'","").replace(":","").replace("""", "").replace("FT","").replace("/", " ").replace("\", " ")
		
			Dim values As String() = line.Split(New Char() {" "c})
			if values.length = 5 Then
				Dim waypoint as string = values(0)
				Dim wpt_name as string = values(1)
				Dim grid as string = values(2)
				Dim coordinate as string = values(3)
				Dim altitude as string = values(4)
								
				VA.WriteToLog("loading waypoint: "+ waypoint + " " + wpt_name + " " + grid + "  " + coordinate + " " + altitude, "blue")
				VA.SetText("waypoint_"+waypoint, waypoint)
				VA.SetText("wpt_name_"+waypoint, wpt_name)
				VA.SetText("grid_"+waypoint, grid)
				VA.SetText("coordinate_"+waypoint, coordinate)
				VA.SetText("altitude_"+waypoint, altitude)
			End if
			
		End If
	Next
	
	End Sub

End Class
