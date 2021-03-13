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
Imports System.Text.RegularExpressions
Imports System.Web.Script.Serialization

Public Class VAInline


	Public Sub Main()
	
		' Set the directory locations that we want to search in
		Dim dir_locations = {
		Environ$("USERPROFILE")+"\Saved Games\DCS.openbeta\Datatape", 
		Environ$("USERPROFILE")+"\Saved Games\DCS\Datatape", 
		"C:\Program Files (x86)\VoiceAttack\Datatape"
		}
		
		' directory and file related variables
		Dim dir_found as Boolean = false
		Dim datatape_dir as String	
		Dim dir_loc as integer = 0
		
		Dim file_found as Boolean = false
		Dim json_file_found as Boolean = false
		Dim datatape_file as string
		
		Dim file_code as string
		
		Dim pos as integer = 2
		Dim current_pos as string
		
		' Clear all variabls firs
		while pos < 101
			VA.SetText("waypoint_"+pos.toString(), nothing)
			VA.SetText("wpt_name_"+pos.toString(), nothing)
			VA.SetText("grid_"+pos.toString(), nothing)
			VA.SetText("coordinate_"+pos.toString(), nothing)
			VA.SetText("altitude_"+pos.toString(), nothing)
			pos = pos + 1
		end while
		
		pos = 2
		
		
		' Look for the available directories and pick the one that works the best based on the order within the list
		while dir_found = false and dir_loc < dir_locations.length
			
			If Directory.Exists(dir_locations(dir_loc)) Then
				dir_found = true
				datatape_dir = dir_locations(dir_loc)
				VA.WriteToLog("Reading data from directory: "+datatape_dir, "blue")
			End If
			dir_loc = dir_loc + 1
			
		end while
		
		' If no directory was found, then it needs to be created/fixed. Output some insturctions on how to do so.
		If dir_found = false then
			If file_code <> nothing then
				VA.WriteToLog("Advanced File Format: a10_datatape_"+file_code+"_<ANYTHING_YOU_WANT_HERE>.txt", "red")
			Else
				VA.WriteToLog("Advanced File Format: a10_datatape_alpha_<ANYTHING_YOU_WANT_HERE>.txt", "red")
			End If
			VA.WriteToLog("Basic File Format: a10_datatape.txt", "red")
			VA.WriteToLog("File name must match one of the following formats:", "red")
			VA.WriteToLog(dir_locations(2), "red")
			VA.WriteToLog(dir_locations(1), "red")
			VA.WriteToLog(dir_locations(0), "red")	
			VA.WriteToLog("In order for datatape to run, you need to create a datatape file in one of the following locations:", "red")	
			VA.WriteToLog("Could not locate data file in directory: "+datatape_dir, "red")
			return
		End If
		
		' If there is a file code like alpha, bravo, etc then we need to load it in now and flush the variable after
		file_code = VA.GetText("file_code")
		VA.SetText("file_code", nothing)
		
		' If there is no file code then just load the old style datatape.txt file. Otherwise load one of the new style
		' Prefer JSON files and fall back to TXT files
		If file_code = "" then
			If File.exists(datatape_dir + "\a10_datatape.txt") then
				datatape_file = datatape_dir + "\a10_datatape.txt"
				file_found = true
			End If
		Else

			datatape_file = Dir(datatape_dir + "\a10_datatape_" + file_code + "*.txt")
			If datatape_file <> "" then
				datatape_file = datatape_dir + "\" + datatape_file
				file_found = true
			End If
		End If
		
		' No files were found and this is bad. Show instructions on what to do. 
		If file_found = false then
			If file_code <> nothing then
				VA.WriteToLog("Advanced File Format: a10_datatape_"+file_code+"_<ANYTHING_YOU_WANT_HERE>.txt", "red")
			Else
				VA.WriteToLog("Advanced File Format: a10_datatape_alpha_<ANYTHING_YOU_WANT_HERE>.txt", "red")
			End If
			VA.WriteToLog("Basic File Format: datatape.txt", "red")
			VA.WriteToLog("File name must match one of the following formats:", "red")
			VA.WriteToLog("Could not locate compatible datatape file", "red")
			return
		End If
			
		' Main loop. Read the file, trim some fat, and get it plugged into vars	
		VA.WriteToLog("Reading from datatape file: "+ datatape_file, "blue")
		
		' Run a dIfferent loop for JSON files.
	
		for each line as string in File.ReadLines(datatape_file)
		
			' We can comment out lines by prepending a # 
			If line.contains("#") = false then
			
				' Trim out any comments within [BRACKETS] 
				line = Regex.replace(line, "\s?\[(.*)\]", "")
		
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
			End If
		Next
	End Sub

End Class
