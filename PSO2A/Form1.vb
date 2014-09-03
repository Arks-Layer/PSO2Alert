Imports System.IO
Imports System.Net
Imports LinqToTwitter
Imports System.Text.RegularExpressions

Public Class Form1
    Public twitterctx As TwitterContext
    Public ProgramEnabled As Boolean
    Public LoggingEnabled As Boolean = False
    Public DisplayMonitor As Integer = 1

    Private Sub Form1_Click(sender As Object, e As EventArgs) Handles Me.Click
        tmrDisplay.Enabled = False
        Me.Opacity = 0
        Me.TopMost = False
    End Sub
    Private Sub CheckForUpdates()
        Dim localVersion As String = My.Application.Info.Version.ToString
        Dim wc As New Net.WebClient
        wc.Proxy = Nothing
        Dim source As String = String.Empty
        If File.Exists(Application.StartupPath & "\PSO2 Alert Updater.exe") Then File.Delete(Application.StartupPath & "\PSO2 Alert Updater.exe")
        Try
            If CheckLink("https://dl.dropboxusercontent.com/u/23005008/candyapples/PSO2Aversion.xml") = "OK" Then source = wc.DownloadString("https://dl.dropboxusercontent.com/u/23005008/candyapples/PSO2Aversion.xml")
            If CheckLink("https://dl.dropboxusercontent.com/u/23005008/candyapples/PSO2Aversion.xml") <> "OK" Then source = wc.DownloadString("http://arks-layer.com/tweaker/PSO2Aversion.xml")
        Catch ex As Exception
            NotifyIcon1.ShowBalloonTip(7000, "", "PSO2 Alert error: Could not check for updates!", ToolTipIcon.Info)
            Threading.Thread.Sleep(7000)
        End Try

        If source.Contains("<VersionHistory>") = True Then

            Dim xm As New Xml.XmlDocument
            xm.LoadXml(source)

            Dim currentVersion As String = xm.SelectSingleNode("//CurrentVersion").ChildNodes(0).InnerText.Trim
            Dim currentLink As String = xm.SelectSingleNode("//CurrentVersion").ChildNodes(1).InnerText.Trim
            Dim changelog As String = xm.SelectSingleNode("//CurrentVersion").ChildNodes(2).InnerText.Trim
            Dim changelog2 As String = xm.SelectSingleNode("//CurrentVersion").ChildNodes(3).InnerText.Trim
            Dim changelog3 As String = xm.SelectSingleNode("//CurrentVersion").ChildNodes(4).InnerText.Trim
            Dim changelog4 As String = xm.SelectSingleNode("//CurrentVersion").ChildNodes(5).InnerText.Trim
            Dim changelog5 As String = xm.SelectSingleNode("//CurrentVersion").ChildNodes(6).InnerText.Trim
            Dim changelog6 As String = xm.SelectSingleNode("//CurrentVersion").ChildNodes(7).InnerText.Trim
            Dim changelog7 As String = xm.SelectSingleNode("//CurrentVersion").ChildNodes(8).InnerText.Trim
            Dim changelog8 As String = xm.SelectSingleNode("//CurrentVersion").ChildNodes(9).InnerText.Trim
            Dim changelog9 As String = xm.SelectSingleNode("//CurrentVersion").ChildNodes(10).InnerText.Trim
            Dim changelog10 As String = xm.SelectSingleNode("//CurrentVersion").ChildNodes(11).InnerText.Trim
            If localVersion <> currentVersion Then
                Dim changelogtotal As String = changelog
                If changelog2 <> "" Then changelogtotal += vbCrLf & changelog2
                If changelog3 <> "" Then changelogtotal += vbCrLf & changelog3
                If changelog4 <> "" Then changelogtotal += vbCrLf & changelog4
                If changelog5 <> "" Then changelogtotal += vbCrLf & changelog5
                If changelog6 <> "" Then changelogtotal += vbCrLf & changelog6
                If changelog7 <> "" Then changelogtotal += vbCrLf & changelog7
                If changelog8 <> "" Then changelogtotal += vbCrLf & changelog8
                If changelog9 <> "" Then changelogtotal += vbCrLf & changelog9
                If changelog10 <> "" Then changelogtotal += vbCrLf & changelog10
                Dim updateyesno As MsgBoxResult = MsgBox("You are using an outdated version of PSO2 Alert. You have version " & My.Application.Info.Version.ToString & " and the latest version is " & currentVersion & ". Would you like to download the latest version?" & vbCrLf & vbCrLf & "Here's the list of changes:" & vbCrLf & changelogtotal, MsgBoxStyle.YesNo)
                If updateyesno = MsgBoxResult.Yes Then
                    Dim wc2 As WebClient = New WebClient()
                    If CheckLink("https://dl.dropboxusercontent.com/u/23005008/candyapples/PSO2%20Alert%20Updater.exe") = "OK" Then wc.DownloadFile("https://dl.dropboxusercontent.com/u/23005008/candyapples/PSO2%20Alert%20Updater.exe", "PSO2 Alert Updater.exe")
                    If CheckLink("https://dl.dropboxusercontent.com/u/23005008/candyapples/PSO2%20Alert%20Updater.exe") <> "OK" Then wc.DownloadFile("http://arks-layer.com/tweaker/PSO2%20Alert%20Updater.exe", "PSO2 Alert Updater.exe")
                    Process.Start(Environment.CurrentDirectory & "\PSO2 Alert Updater.exe")
                End If
            End If
        End If
    End Sub
    Private Sub InitialEQCheck()
        Dim client As New System.Net.WebClient()
        If CheckLink("http://arks-layer.com/twitter/getEQ.php?ship=" & LoadSetting("ShipToQuery")) <> "OK" Then Exit Sub
        Dim json = client.DownloadString("http://arks-layer.com/twitter/getEQ.php?ship=" & LoadSetting("ShipToQuery"))
        'MsgBox(json) 
        Dim jss As New System.Web.Script.Serialization.JavaScriptSerializer()
        Dim dict As JSON_result = jss.Deserialize(Of JSON_result)(json)
        Dim RandomIDShit As String = dict.id
        Dim BeginTime As String = dict.from
        Dim EnglishName As String = dict.english
        Dim EQImage As String = dict.img
        Dim Ship As String = dict.name
        Dim EQText As String = dict.text
        Dim StopTime As String = dict.until
        Dim base As New DateTime(1970, 1, 1)
        Dim StartTime As DateTime = base.AddMilliseconds(BeginTime)
        Dim EndTime As DateTime = base.AddMilliseconds(StopTime)
        Dim ConvertedStartTime As DateTime = StartTime.ToLocalTime
        Dim CST2 As String = ConvertedStartTime.ToString("M/d/yyyy hh:mm:ss tt")
        Dim ConvertedEndTime As DateTime = EndTime.ToLocalTime
        'Dim Currenttime As DateTime = TimeOfDay.ToUniversalTime
        'Dim CurrentTimeConverted As DateTime = Currenttime.ToLocalTime
        'MsgBox("Current UTC time is: " & Currenttime & ". Converted local time is: " & CurrentTimeConverted & ".")
        'Me.Close()
        'TextBox1.Text = ("The EQ -" & EQText & "- on -" & Ship & "- will start at -" & ConvertedStartTime & "- and end at -" & ConvertedEndTime & "-, using -" & EQImage & "- as the image!")
        If LoadSetting("LastEQ") <> json Then
            If LoadSetting("PlaySound") = "Yes" Then
                'MsgBox("Yo!")
                If File.Exists(LoadSetting("WAVFile")) = True Then
                    My.Computer.Audio.Play(LoadSetting("WAVFile"), AudioPlayMode.Background)
                Else
                    NotifyIcon1.ShowBalloonTip(7000, "PSO2 Alert", "WAV file not found!", ToolTipIcon.Info)
                End If
            End If
            ShowEQ(Ship, EQText, CST2, ConvertedEndTime, EQImage, "1", EnglishName)
            SaveSetting("LastEQ", json)
        End If
        SaveSetting("LastEQ", json)
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        '        If LoadSetting("Arks Ship Fire Swirl") = "" Then Sa
        If LoadSetting("Arks Ship Fire Swirl") <> "" Then ArksShipFireSwirlToolStripMenuItem.Checked = LoadSetting("Arks Ship Fire Swirl")
        If LoadSetting("Brave Border Break") <> "" Then BraveBorderBreakToolStripMenuItem.Checked = LoadSetting("Brave Border Break")
        If LoadSetting("Caves") <> "" Then CavesToolStripMenuItem.Checked = LoadSetting("Caves")
        If LoadSetting("Urban") <> "" Then UrbanToolStripMenuItem.Checked = LoadSetting("Urban")
        If LoadSetting("Coast") <> "" Then CoastToolStripMenuItem.Checked = LoadSetting("Coast")
        If LoadSetting("Cradle of Darkness") <> "" Then CradleOfDarknessToolStripMenuItem.Checked = LoadSetting("Cradle of Darkness")
        If LoadSetting("Dark Falz") <> "" Then DarkFalzToolStripMenuItem.Checked = LoadSetting("Dark Falz")
        If LoadSetting("Desert") <> "" Then DesertToolStripMenuItem.Checked = LoadSetting("Desert")
        If LoadSetting("Super Falz") <> "" Then SuperFalzToolStripMenuItem.Checked = LoadSetting("Super Falz")
        If LoadSetting("Floating Continent") <> "" Then FloatingContinentToolStripMenuItem.Checked = LoadSetting("Floating Continent")
        If LoadSetting("Forest") <> "" Then ForestToolStripMenuItem.Checked = LoadSetting("Forest")
        If LoadSetting("Merry Christmas on Ice") <> "" Then MerryChristmasOnIceToolStripMenuItem.Checked = LoadSetting("Merry Christmas on Ice")
        If LoadSetting("Mining Base Defense") <> "" Then MiningBaseDefenseToolStripMenuItem.Checked = LoadSetting("Mining Base Defense")
        If LoadSetting("Trick or Treat") <> "" Then TrickOrTreatToolStripMenuItem.Checked = LoadSetting("Trick or Treat")
        If LoadSetting("Tunnels") <> "" Then TunnelsToolStripMenuItem.Checked = LoadSetting("Tunnels")
        If LoadSetting("With Wind And Rain") <> "" Then WithWindAndRainToolStripMenuItem.Checked = LoadSetting("With Wind And Rain")
        'SaveSetting("Arks Ship Fire Swirl", ArksShipFireSwirlToolStripMenuItem.Checked)
        'Uncomment to continue on multi-monitor support
        'Dim numberofmonitors As Integer = Screen.AllScreens.Length
        'If numberofmonitors = 2 Then
        ' tsmSelectMonitor.Visible = True
        ' End If

        'If IsConnected() = False Then
        ' MsgBox("Sorry, you don't appear to be online, and this program requires you to be." & vbCrLf & "(Either that, or Google is offline, in which case the world has already ended.)")
        ' Application.Exit()
        ' Exit Sub
        ' End If
        Dim t1 As New Threading.Thread(AddressOf CheckForUpdates)
        t1.IsBackground = True
        t1.Start()

        NotifyIcon1.Visible = False
        If LoadSetting("PlaySound") = "Yes" Then
            If File.Exists(LoadSetting("WAVFile")) = True Then
                tsmSound.Checked = True
            End If
        End If
        If LoadSetting("StartWithWindows") = "Yes" Then tsmStartWithWindows.Checked = True
        If LoadSetting("ShipToQuery") = "" Then SaveSetting("ShipToQuery", "Ship02")
        tscShip.Text = LoadSetting("ShipToQuery")
        'tsmDebugShowEQ.Visible = True
        'If My.Settings.Ship = "" Then My.Settings.Ship = "Ship02"
        Me.Opacity = 0
        NotifyIcon1.Visible = True
        tsmVersion.Text = "PSO2 Alert v" & My.Application.Info.Version.ToString
        NotifyIcon1.ShowBalloonTip(7000, "", "PSO2 Alert v" & My.Application.Info.Version.ToString & " is now ready and waiting for EQ alerts", ToolTipIcon.Info)
        Dim t2 As New Threading.Thread(AddressOf InitialEQCheck)
        t2.IsBackground = True
        t2.Start()


        'Method 2 [DEPRECATED AS OF 1-12-2014]
        'Dim net As New Net.WebClient()
        'Dim src As String
        'src = net.DownloadString("https://twitter.com/psowAIDA")
        'MsgBox(src.ToString)
        ' Create a match using regular exp<b></b>ressions
        'http://arks-layer.com/Story%20Patch%208-8-2013.rar.torrent
        'Wildcare is .*?
        'Dim m As Match = Regex.Match(src, "<p class=""js-tweet-text tweet-text"">.*?</p>")
        'MsgBox(m.Value)
        ' Spit out the value plucked from the code
        'MsgBox(m.Value)
        'Dim EQString As String = m.Value
        'EQString = EQString.Replace("<p class=""js-tweet-text tweet-text"">", "")
        'EQString = EQString.Replace("</p>", "")
        'If LoadSetting("EQSystem2") = "" Then SaveSetting("EQSystem2", EQString)
        'If LoadSetting("EQSystem2") <> EQString Then
        'If EQString.Contains("pso2eqs2") Then
        'MsgBox(EQString)
        'Dim EQArray() As String = EQString.Split(" ")
        'MsgBox(EQArray(0)) 'pso2eqs2
        'MsgBox(EQArray(1)) 'ship02
        'MsgBox(EQArray(2)) 'fire
        'Dim EQType As String = EQArray(2)
        'MsgBox(EQArray(3)) '1030-1100
        'Dim ThrowawayTimefromSystem2() As String = EQArray(3).Split("-")
        'Dim StartTimeFromS2 As String = ThrowawayTimefromSystem2(0)
        'Dim EndTimeFromS2 As String = ThrowawayTimefromSystem2(1)
        'MsgBox(StartTimeFromS2)
        'MsgBox(EndTimeFromS2)
        'MsgBox(ToTime(StartTimeFromS2))
        'MsgBox(ToTime(EndTimeFromS2))
        'StartTimeFromS2 = ToTime(StartTimeFromS2)
        'EndTimeFromS2 = ToTime(EndTimeFromS2)
        'StartTimeFromS2 = StartTimeFromS2.Replace(" AM", "")
        'StartTimeFromS2 = StartTimeFromS2.Replace(" PM", "")
        'EndTimeFromS2 = EndTimeFromS2.Replace(" AM", "")
        'EndTimeFromS2 = EndTimeFromS2.Replace(" PM", "")
        'Dim IMG As String
        'Dim EQText2 As String
        'If EQType = "fire" Then
        'EQText2 = "A fire has broken out in the city area. Report immediately to get the area under control."
        'IMG = "http://arks-layer.com/twitter/images/pso2_51e521f1ab253.png"
        'ElseIf EQType = "amduscia" Then
        'EQText2 = "Arks is preparing for large scale operations on planet Amduscia, Caves."
        'IMG = "http://arks-layer.com/twitter/images/pso2_51e3b4da8c642.png"
        'ElseIf EQType = "urban" Then
        'EQText2 = "Darkers have invaded the civilian sector. All Arks dispatch to restore the area."
        'IMG = "http://arks-layer.com/twitter/images/pso2_51e3d9c97f89d.png"
        'ElseIf EQType = "vopar" Then
        'EQText2 = "Arks is preparing for large scale operations on planet Vorpar, Coast."
        'IMG = "http://arks-layer.com/twitter/images/pso2_522abdfa29c25.png"
        'ElseIf EQType = "falz" Then
        'EQText2 = "Dark Falz is approaching Oracle. All Arks report to the mission counter at once!"
        'IMG = "http://arks-layer.com/twitter/images/pso2_51e3d6e34b936.png"
        'ElseIf EQType = "lilipa" Then
        'EQText2 = "Arks is preparing for large scale operations on planet Lilipa, Desert."
        'IMG = "http://arks-layer.com/twitter/images/pso2_51e1b3d369ead.png"
        'ElseIf EQType = "naberius" Then
        'EQText2 = "Arks is preparing for large scale operations on planet Naberius, Forest."
        'IMG = "http://arks-layer.com/twitter/images/pso2_51e3da34918fe.png"
        'ElseIf EQType = "superfalz" Then
        'EQText2 = "A fragment of Dark Falz is approaching Oracle at an incredible rate! All Arks report to the mission counter to drive him back!"
        'IMG = "http://arks-layer.com/twitter/images/pso2_51e3d6e34b936.png"
        'ElseIf EQType = "allplanets" Then
        'EQText2 = "An influx of enemies have appeared on planet Naberius, Forest. All Arks, prepare to investigate."
        'IMG = "http://arks-layer.com/twitter/images/pso2_523ede034e26d.bmp"
        'Else
        'EQText2 = "Arks is preparing for large scale operations. No information is currently available."
        'IMG = "http://arks-layer.com/twitter/images/pso2_522c0d01ea0fd.png"
        'End If
        'ShowEQ("Ship02", EQText2, StartTimeFromS2, EndTimeFromS2, IMG, "2")
        'SaveSetting("EQSystem2", EQString)
        'End If
        'End If
    End Sub
    Public Shared Function ToTime(str As String) As String
        Dim dt As DateTime = DateTime.Now
        Try
            Dim formats As String() = New String() {"HHmm"}
            dt = DateTime.ParseExact(str, formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.AdjustToUniversal)
        Catch
            Throw New Exception("Invalid data")
        End Try
        Return dt.ToShortTimeString()
    End Function

    Private Sub CheckForEQs1()
        Dim client As New System.Net.WebClient()
        'https://copy.com/MeU8A0svvEB9qeq7
        'Dim json = client.DownloadString("https://copy.com/MeU8A0svvEB9qeq7")
        If CheckLink("http://arks-layer.com/twitter/getEQ.php?ship=" & LoadSetting("ShipToQuery")) <> "OK" Then Exit Sub
        Dim json = client.DownloadString("http://arks-layer.com/twitter/getEQ.php?ship=" & LoadSetting("ShipToQuery"))
        'MsgBox(json) '
        '1380293580000
        '1380281400000
        Dim jss As New System.Web.Script.Serialization.JavaScriptSerializer()
        Dim dict As JSON_result = jss.Deserialize(Of JSON_result)(json)
        Dim RandomIDShit As String = dict.id
        Dim EnglishName As String = dict.english
        Dim BeginTime As String = dict.from
        Dim EQImage As String = dict.img
        Dim Ship As String = dict.name
        Dim EQText As String = dict.text
        Dim StopTime As String = dict.until
        Dim base As New DateTime(1970, 1, 1)
        Dim StartTime As DateTime = base.AddMilliseconds(BeginTime)
        Dim EndTime As DateTime = base.AddMilliseconds(StopTime)
        Dim ConvertedStartTime As DateTime = StartTime.ToLocalTime
        Dim CST2 As String = ConvertedStartTime.ToString("M/d/yyyy hh:mm:ss tt")
        Dim ConvertedEndTime As DateTime = EndTime.ToLocalTime
        Dim CurrentTime As DateTime = Date.Now
        If LoadSetting("LastEQ") <> json Then
            If LoadSetting("PlaySound") = "Yes" Then
                'MsgBox("Yo!")
                If File.Exists(LoadSetting("WAVFile")) = True Then
                    My.Computer.Audio.Play(LoadSetting("WAVFile"), AudioPlayMode.Background)
                Else
                    NotifyIcon1.ShowBalloonTip(7000, "PSO2 Alert", "WAV file not found!", ToolTipIcon.Info)
                End If
            End If
            ShowEQ(Ship, EQText, CST2, ConvertedEndTime, EQImage, "1", EnglishName)
            SaveSetting("LastEQ", json)
        End If
    End Sub
Private Sub tmrCheck_Tick(sender As Object, e As EventArgs) Handles tmrCheck.Tick
        Try

            Dim t1 As New Threading.Thread(AddressOf CheckForEQs1)
            t1.IsBackground = True
            t1.Start()
            'If ProgramEnabled = False Then Exit Sub

            'If Date.Now > ConvertedStartTime And Date.Now < ConvertedEndTime Then
            'ShowEQ(Ship, EQText, ConvertedStartTime, ConvertedEndTime, EQImage)
            ' End If

            'Method 2
            'Dim net As New Net.WebClient()
            'Dim src As String
            'src = net.DownloadString("https://twitter.com/psowAIDA")
            'MsgBox(src.ToString)
            ' Create a match using regular exp<b></b>ressions
            'http://arks-layer.com/Story%20Patch%208-8-2013.rar.torrent
            'Wildcare is .*?
            'Dim m As Match = Regex.Match(src, "<p class=""js-tweet-text tweet-text"">.*?</p>")
            'MsgBox(m.Value)
            ' Spit out the value plucked from the code
            'MsgBox(m.Value)
            'Dim EQString As String = m.Value
            'EQString = EQString.Replace("<p class=""js-tweet-text tweet-text"">", "")
            'EQString = EQString.Replace("</p>", "")
            'If LoadSetting("EQSystem2") = "" Then SaveSetting("EQSystem2", EQString)
            'If LoadSetting("EQSystem2") <> EQString Then
            ' If EQString.Contains("pso2eqs2") Then
            ' 'MsgBox(EQString)
            ' Dim EQArray() As String = EQString.Split(" ")
            ' 'MsgBox(EQArray(0)) 'pso2eqs2
            ' 'MsgBox(EQArray(1)) 'ship02
            ' 'MsgBox(EQArray(2)) 'fire
            ' Dim EQType As String = EQArray(2)
            ' 'MsgBox(EQArray(3)) '1030-1100
            ' Dim ThrowawayTimefromSystem2() As String = EQArray(3).Split("-")
            ' Dim StartTimeFromS2 As String = ThrowawayTimefromSystem2(0)
            ' Dim EndTimeFromS2 As String = ThrowawayTimefromSystem2(1)
            ' 'MsgBox(StartTimeFromS2)
            ' 'MsgBox(EndTimeFromS2)
            ' 'MsgBox(ToTime(StartTimeFromS2))
            ' 'MsgBox(ToTime(EndTimeFromS2))
            ' StartTimeFromS2 = ToTime(StartTimeFromS2)
            ' EndTimeFromS2 = ToTime(EndTimeFromS2)
            ' StartTimeFromS2 = StartTimeFromS2.Replace(" AM", "")
            ' StartTimeFromS2 = StartTimeFromS2.Replace(" PM", "")
            ' EndTimeFromS2 = EndTimeFromS2.Replace(" AM", "")
            ' EndTimeFromS2 = EndTimeFromS2.Replace(" PM", "")
            ' Dim IMG As String
            ' Dim EQText2 As String
            ' If EQType = "fire" Then
            ' EQText2 = "A fire has broken out in the city area. Report immediately to get the area under control."
            ' IMG = "http://arks-layer.com/twitter/images/pso2_51e521f1ab253.png"
            ' ElseIf EQType = "amduscia" Then
            ' EQText2 = "Arks is preparing for large scale operations on planet Amduscia, Caves."
            ' IMG = "http://arks-layer.com/twitter/images/pso2_51e3b4da8c642.png"
            ' ElseIf EQType = "urban" Then
            ' EQText2 = "Darkers have invaded the civilian sector. All Arks dispatch to restore the area."
            ' IMG = "http://arks-layer.com/twitter/images/pso2_51e3d9c97f89d.png"
            ' ElseIf EQType = "vopar" Then
            ' EQText2 = "Arks is preparing for large scale operations on planet Vorpar, Coast."
            ' IMG = "http://arks-layer.com/twitter/images/pso2_522abdfa29c25.png"
            ' ElseIf EQType = "falz" Then
            ' EQText2 = "Dark Falz is approaching Oracle. All Arks report to the mission counter at once!"
            ' IMG = "http://arks-layer.com/twitter/images/pso2_51e3d6e34b936.png"
            ' ElseIf EQType = "lilipa" Then
            ' EQText2 = "Arks is preparing for large scale operations on planet Lilipa, Desert."
            ' IMG = "http://arks-layer.com/twitter/images/pso2_51e1b3d369ead.png"
            ' ElseIf EQType = "naberius" Then
            ' EQText2 = "Arks is preparing for large scale operations on planet Naberius, Forest."
            ' IMG = "http://arks-layer.com/twitter/images/pso2_51e3da34918fe.png"
            ' ElseIf EQType = "superfalz" Then
            ' EQText2 = "A fragment of Dark Falz is approaching Oracle at an incredible rate! All Arks report to the mission counter to drive him back!"
            ' IMG = "http://arks-layer.com/twitter/images/pso2_51e3d6e34b936.png"
            ' ElseIf EQType = "allplanets" Then
            ' EQText2 = "An influx of enemies have appeared on planet Naberius, Forest. All Arks, prepare to investigate."
            ' IMG = "http://arks-layer.com/twitter/images/pso2_523ede034e26d.bmp"
            ' Else
            ' EQText2 = "Arks is preparing for large scale operations. No information is currently available."
            ' IMG = "http://arks-layer.com/twitter/images/pso2_522c0d01ea0fd.png"
            ' End If
            ' ShowEQ("Ship02", EQText2, StartTimeFromS2, EndTimeFromS2, IMG, "2")
            ' SaveSetting("EQSystem2", EQString)
            ' End If
            ' End If
        Catch ex As Exception

        End Try
End Sub
    'Function IsConnected() As Boolean
    '    Try
    '        Return My.Computer.Network.Ping("google.com")
    '    Catch ex As Exception
    '        Return False
    '    End Try
    'End Function
    Public Sub ShowEQ(ByRef Ship As String, EQText As String, StartTime As String, EndTime As String, EQImage As String, Version As String, EnglishName As String)
        'If EQText = "A fragment of Dark Falz is approaching Oracle at an incredible rate! All Arks report to the mission counter to drive him back!" Then
        ' lblEQText.Font = New Drawing.Font("Cambria", 10)
        ' Else
        ' lblEQText.Font = New Drawing.Font("Cambria", 12)
        ' End If
        If EnglishName = "Arks Ship Fire Swirl" And ArksShipFireSwirlToolStripMenuItem.Checked = False Then Exit Sub
        If EnglishName = "Brave Border Break" And BraveBorderBreakToolStripMenuItem.Checked = False Then Exit Sub
        If EnglishName = "Caves" And CavesToolStripMenuItem.Checked = False Then Exit Sub
        If EnglishName = "City" And UrbanToolStripMenuItem.Checked = False Then Exit Sub
        If EnglishName = "Coast" And CoastToolStripMenuItem.Checked = False Then Exit Sub
        If EnglishName = "Cradle of Darkness" And CradleOfDarknessToolStripMenuItem.Checked = False Then Exit Sub
        If EnglishName = "Dark Falz" And DarkFalzToolStripMenuItem.Checked = False Then Exit Sub
        If EnglishName = "Desert" And DesertToolStripMenuItem.Checked = False Then Exit Sub
        If EnglishName = "Falz Elder Fragment" And SuperFalzToolStripMenuItem.Checked = False Then Exit Sub
        If EnglishName = "Floating Continent" And FloatingContinentToolStripMenuItem.Checked = False Then Exit Sub
        If EnglishName = "Forest" And ForestToolStripMenuItem.Checked = False Then Exit Sub
        If EnglishName = "Merry Christmas on Ice" And MerryChristmasOnIceToolStripMenuItem.Checked = False Then Exit Sub
        If EnglishName = "Mining Base Defense: Tower Defense" And MiningBaseDefenseToolStripMenuItem.Checked = False Then Exit Sub
        If EnglishName = "Trick or Treat" And TrickOrTreatToolStripMenuItem.Checked = False Then Exit Sub
        If EnglishName = "Tunnels" And TunnelsToolStripMenuItem.Checked = False Then Exit Sub
        If EnglishName = "With Wind And Rain" And WithWindAndRainToolStripMenuItem.Checked = False Then Exit Sub

        If Me.InvokeRequired Then
            Me.Invoke(New Action(Of String)(AddressOf ShowRecentEQs), Text)
        Else
            Me.Opacity = 100
            Me.TopMost = True
            If DisplayMonitor = 1 Then
                Dim x As Integer
                Dim y As Integer
                x = Screen.PrimaryScreen.WorkingArea.Width - Me.Width
                y = Screen.PrimaryScreen.WorkingArea.Height - (Me.Height - 1)
                Me.Location = New Point(x, y)
                'MsgBox("X: " & x & " Y: " & y)
            End If
            If DisplayMonitor = 2 Then
                Dim x As Integer
                Dim y As Integer

                'x = Screen.AllScreens(1).Bounds.X ' - Me.Width
                x = 0 - Me.Width
                y = Screen.AllScreens(1).Bounds.Height - (Me.Height - 10)
                'y = Screen.AllScreens(1).Bounds.Y ' - (Me.Height - 1)

                'Me.Location = New Point(Screen.AllScreens(1).Bounds.X, Screen.AllScreens(1).Bounds.Y)

                Me.Location = New Point(x, y)
                'MsgBox("X: " & x & " Y: " & y)
            End If
            picEQImage.ImageLocation = EQImage
            Application.DoEvents()
            lblEQText.Text = EQText
            If Version = "1" Then
                Dim StartTimeJustTime() As String = Split(StartTime, " ")
                Dim EndTimeJustTime() As String = Split(EndTime, " ")
                Dim FINALSTARTTIME As String = StartTimeJustTime(1)
                FINALSTARTTIME = FINALSTARTTIME.Substring(0, FINALSTARTTIME.Length - 3)
                Dim FINALENDTIME As String = EndTimeJustTime(1)
                FINALENDTIME = FINALENDTIME.Substring(0, FINALENDTIME.Length - 3)
                lblTitle.Text = Ship & " EQ (" & FINALSTARTTIME & " - " & FINALENDTIME & ")"
                If LoggingEnabled = True Then
                    Dim strFile As String = Application.StartupPath & "\EQLog.txt"
                    Using sw As New StreamWriter(File.Open(strFile, FileMode.Append))
                        sw.WriteLine(Ship & " EQ (" & FINALSTARTTIME & "0 - " & FINALENDTIME & "0): " & EQText & vbCrLf)
                    End Using
                End If
            End If
            'If Version = "2" Then lblTitle.Text = Ship & " EQ (" & StartTime & " - " & EndTime & ")"
            Application.DoEvents()
            tmrDisplay.Enabled = True
            'Me.Close()
        End If
    End Sub
    Public Function LoadSetting(ByRef SettingLabel As String)
        Dim ReturnString As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\AIDA", SettingLabel, "")
        Return ReturnString
    End Function
    Public Sub SaveSetting(ByRef SettingLabel As String, ByRef SettingValue As String)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\AIDA", SettingLabel, SettingValue)
    End Sub

    Private Sub tsmExit_Click(sender As Object, e As EventArgs) Handles tsmExit.Click
        NotifyIcon1.Visible = False
        Me.Close()
    End Sub
    Private Sub tmrDisplay_Tick(sender As Object, e As EventArgs) Handles tmrDisplay.Tick
        Dim iCount As Integer
        For iCount = 90 To 0 Step -10
            Me.Opacity = iCount / 100
            Me.Refresh()
            Threading.Thread.Sleep(50)
        Next
        Me.TopMost = False
        tmrDisplay.Enabled = False
    End Sub

    Private Sub tsmASFS_Click(sender As Object, e As EventArgs) Handles tsmASFS.Click
        ShowEQ("Ship02", "A fire has broken out in the city area. Report immediately to get the area under control.", "9/27/2013 12:00AM", "9/27/2013 12:30PM", "http://arks-layer.com/twitter/images/pso2_51e521f1ab253.png", "1", "Arks Ship Fire Swirl")
    End Sub

    Private Sub tsmCaves_Click(sender As Object, e As EventArgs) Handles tsmCaves.Click
        ShowEQ("Ship02", "Arks is preparing for large scale operations on planet Amduscia, Caves.", "9/27/2013 12:00AM", "9/27/2013 12:30PM", "http://arks-layer.com/twitter/images/pso2_51e3b4da8c642.png", "1", "Caves")
    End Sub

    Private Sub tsmCity_Click(sender As Object, e As EventArgs) Handles tsmCity.Click
        ShowEQ("Ship02", "Darkers have invaded the civilian sector. All Arks dispatch to restore the area.", "9/27/2013 12:00AM", "9/27/2013 12:30PM", "http://arks-layer.com/twitter/images/pso2_51e3d9c97f89d.png", "1", "City")
    End Sub

    Private Sub tsmCoast_Click(sender As Object, e As EventArgs) Handles tsmCoast.Click
        ShowEQ("Ship02", "Arks is preparing for large scale operations on planet Vorpar, Coast.", "9/27/2013 12:00AM", "9/27/2013 12:30PM", "http://arks-layer.com/twitter/images/pso2_522abdfa29c25.png", "1", "")
    End Sub

    Private Sub tsmDarkFalz_Click(sender As Object, e As EventArgs) Handles tsmDarkFalz.Click
        ShowEQ("Ship02", "Dark Falz is approaching Oracle. All Arks report to the mission counter at once!", "9/27/2013 12:00AM", "9/27/2013 12:30PM", "http://arks-layer.com/twitter/images/pso2_51e3d6e34b936.png", "1", "")
    End Sub

    Private Sub tsmDesert_Click(sender As Object, e As EventArgs) Handles tsmDesert.Click
        ShowEQ("Ship02", "Arks is preparing for large scale operations on planet Lilipa, Desert.", "9/27/2013 12:00AM", "9/27/2013 12:30PM", "http://arks-layer.com/twitter/images/pso2_51e1b3d369ead.png", "1", "")
    End Sub

    Private Sub tsmFloating_Click(sender As Object, e As EventArgs) Handles tsmFloating.Click
        ShowEQ("Ship02", "Arks is preparing for large scale operations on the Floating Continent, Amduscia.", "9/27/2013 12:00AM", "9/27/2013 12:30PM", "http://arks-layer.com/twitter/images/pso2_51f2131743674.png", "1", "")
    End Sub

    Private Sub tsmForest_Click(sender As Object, e As EventArgs) Handles tsmForest.Click
        ShowEQ("Ship02", "Arks is preparing for large scale operations on planet Naberius, Forest.", "9/27/2013 12:00AM", "9/27/2013 12:30PM", "http://arks-layer.com/twitter/images/pso2_51e3da34918fe.png", "1", "")
    End Sub

    Private Sub tsmGeneral_Click(sender As Object, e As EventArgs) Handles tsmGeneral.Click
        ShowEQ("Ship02", "Arks is preparing for large scale operations. No information is currently available.", "9/27/2013 12:00AM", "9/27/2013 12:30PM", "http://arks-layer.com/twitter/images/pso2_522c0d01ea0fd.png", "1", "")
    End Sub

    Private Sub tsmSuperFalz_Click(sender As Object, e As EventArgs) Handles tsmSuperFalz.Click
        ShowEQ("Ship02", "A fragment of Dark Falz is approaching Oracle at an incredible rate! All Arks report to the mission counter to drive him back!", "9/27/2013 12:00AM", "9/27/2013 12:30PM", "http://arks-layer.com/twitter/images/pso2_51e3d6e34b936.png", "1", "")
    End Sub

    Private Sub tsmTunnels_Click(sender As Object, e As EventArgs) Handles tsmTunnels.Click
        ShowEQ("Ship02", "Arks is preparing for large scale operations on planet Lilipa, Tunnels.", "9/27/2013 12:00AM", "9/27/2013 12:30PM", "http://arks-layer.com/twitter/images/pso2_51e3da03c6b16.png", "1", "")
    End Sub

    Private Sub tsmWindAndRain_Click(sender As Object, e As EventArgs) Handles tsmWindAndRain.Click
        ShowEQ("Ship02", "An influx of enemies have appeared on planet Naberius, Forest. All Arks, prepare to investigate.", "9/27/2013 12:00AM", "9/27/2013 12:30PM", "http://arks-layer.com/twitter/images/pso2_523ede034e26d.bmp", "1", "")
    End Sub

    Private Sub lblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        tmrDisplay.Enabled = False
        Me.Opacity = 0
        Me.TopMost = False
    End Sub

    Private Sub ShowRecentEQs()
        Dim client As New System.Net.WebClient()
        Dim json = client.DownloadString("http://arks-layer.com/twitter/getEQ.php?ship=" & LoadSetting("ShipToQuery"))
        'MsgBox(json)
        Dim jss As New System.Web.Script.Serialization.JavaScriptSerializer()
        Dim dict As JSON_result = jss.Deserialize(Of JSON_result)(json)
        Dim RandomIDShit As String = dict.id
        Dim BeginTime As String = dict.from
        Dim EnglishName As String = dict.english
        Dim EQImage As String = dict.img
        Dim Ship As String = dict.name
        Dim EQText As String = dict.text
        Dim StopTime As String = dict.until
        Dim base As New DateTime(1970, 1, 1)
        Dim StartTime As DateTime = base.AddMilliseconds(BeginTime)
        Dim EndTime As DateTime = base.AddMilliseconds(StopTime)
        Dim ConvertedStartTime As DateTime = StartTime.ToLocalTime
        Dim CST2 As String = ConvertedStartTime.ToString("M/d/yyyy hh:mm:ss tt")
        Dim ConvertedEndTime As DateTime = EndTime.ToLocalTime
        Dim CurrentTime As DateTime = Date.Now
        ShowEQ(Ship, EQText, CST2, ConvertedEndTime, EQImage, "1", EnglishName)
    End Sub

    Private Sub tsmShowRecentEQ_Click(sender As Object, e As EventArgs) Handles tsmShowRecentEQ.Click

        Dim t2 As New Threading.Thread(AddressOf ShowRecentEQs)
        t2.IsBackground = True
        t2.Start()
    End Sub
    Private Sub tscShip_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tscShip.SelectedIndexChanged
        If NotifyIcon1.Visible = True Then
            SaveSetting("ShipToQuery", tscShip.Text)
        End If
    End Sub

    Private Sub tscShip_Click(sender As Object, e As EventArgs) Handles tscShip.Click

    End Sub

    Private Sub lblEQText_Click(sender As Object, e As EventArgs) Handles lblEQText.Click
        tmrDisplay.Enabled = False
        Me.Opacity = 0
        Me.TopMost = False
    End Sub

    Private Sub tsmSound_Click(sender As Object, e As EventArgs) Handles tsmSound.Click
        If tsmSound.Checked = True Then
            MsgBox("Sound playing disabled!")
            tsmSound.Checked = False
            Exit Sub
        End If
        MsgBox("Please select a WAV file that will be played whenever an EQ is announced." & vbCrLf & vbCrLf & "You can view a list of various downloadable PSO2 sounds at the PSO2 Alert thread on PSOWorld.com's forums.")
SELECTFILE:
        'My.Computer.Audio.Play("C:\audio.wav", AudioPlayMode.Background)
        'My.Computer.Audio.Stop()
        OpenFileDialog1.Title = "Please select a WAV file"
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "WAV files|*.wav"
        Dim result = OpenFileDialog1.ShowDialog()
        If result = DialogResult.Cancel Then
            Exit Sub
        End If
        If System.IO.Path.GetExtension(OpenFileDialog1.FileName.ToString()) <> ".wav" Then
            MsgBox("Please select a valid wav file!")
            GoTo SELECTFILE
        End If
        SaveSetting("WAVFile", OpenFileDialog1.FileName.ToString())
        SaveSetting("PlaySound", "Yes")
        tsmSound.Checked = True
    End Sub

    Private Sub tsmStartWithWindows_Click(sender As Object, e As EventArgs) Handles tsmStartWithWindows.Click
        If tsmStartWithWindows.Checked = True Then
            My.Computer.Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True).DeleteValue(Application.ProductName)
            tsmStartWithWindows.Checked = False
            SaveSetting("StartWithWindows", "No")
            Exit Sub
        End If
        My.Computer.Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True).SetValue(Application.ProductName, Application.ExecutablePath)
        SaveSetting("StartWithWindows", "Yes")
        tsmStartWithWindows.Checked = True
    End Sub

    Private Sub tmrCheckforUpdates_Tick(sender As Object, e As EventArgs) Handles tmrCheckforUpdates.Tick
        Try
            Dim localVersion As String = My.Application.Info.Version.ToString
            Dim wc As New Net.WebClient
            wc.Proxy = Nothing
            Dim source As String = String.Empty
            If CheckLink("https://dl.dropboxusercontent.com/u/23005008/candyapples/PSO2Aversion.xml") = "OK" Then source = wc.DownloadString("https://dl.dropboxusercontent.com/u/23005008/candyapples/PSO2Aversion.xml")
            If CheckLink("https://dl.dropboxusercontent.com/u/23005008/candyapples/PSO2Aversion.xml") <> "OK" Then source = wc.DownloadString("http://arks-layer.com/tweaker/PSO2Aversion.xml")

            If source.Contains("<VersionHistory>") = True Then

                Dim xm As New Xml.XmlDocument
                xm.LoadXml(source)

                Dim currentVersion As String = xm.SelectSingleNode("//CurrentVersion").ChildNodes(0).InnerText.Trim
                Dim currentLink As String = xm.SelectSingleNode("//CurrentVersion").ChildNodes(1).InnerText.Trim
                Dim changelog As String = xm.SelectSingleNode("//CurrentVersion").ChildNodes(2).InnerText.Trim
                Dim changelog2 As String = xm.SelectSingleNode("//CurrentVersion").ChildNodes(3).InnerText.Trim
                Dim changelog3 As String = xm.SelectSingleNode("//CurrentVersion").ChildNodes(4).InnerText.Trim
                Dim changelog4 As String = xm.SelectSingleNode("//CurrentVersion").ChildNodes(5).InnerText.Trim
                Dim changelog5 As String = xm.SelectSingleNode("//CurrentVersion").ChildNodes(6).InnerText.Trim
                Dim changelog6 As String = xm.SelectSingleNode("//CurrentVersion").ChildNodes(7).InnerText.Trim
                Dim changelog7 As String = xm.SelectSingleNode("//CurrentVersion").ChildNodes(8).InnerText.Trim
                Dim changelog8 As String = xm.SelectSingleNode("//CurrentVersion").ChildNodes(9).InnerText.Trim
                Dim changelog9 As String = xm.SelectSingleNode("//CurrentVersion").ChildNodes(10).InnerText.Trim
                Dim changelog10 As String = xm.SelectSingleNode("//CurrentVersion").ChildNodes(11).InnerText.Trim
                If localVersion <> currentVersion Then
                    Dim changelogtotal As String = changelog
                    If changelog2 <> "" Then changelogtotal += vbCrLf & changelog2
                    If changelog3 <> "" Then changelogtotal += vbCrLf & changelog3
                    If changelog4 <> "" Then changelogtotal += vbCrLf & changelog4
                    If changelog5 <> "" Then changelogtotal += vbCrLf & changelog5
                    If changelog6 <> "" Then changelogtotal += vbCrLf & changelog6
                    If changelog7 <> "" Then changelogtotal += vbCrLf & changelog7
                    If changelog8 <> "" Then changelogtotal += vbCrLf & changelog8
                    If changelog9 <> "" Then changelogtotal += vbCrLf & changelog9
                    If changelog10 <> "" Then changelogtotal += vbCrLf & changelog10
                    Dim updateyesno As MsgBoxResult = MsgBox("You are using an outdated version of PSO2 Alert. You have version " & My.Application.Info.Version.ToString & " and the latest version is " & currentVersion & ". Would you like to download the latest version?" & vbCrLf & vbCrLf & "Here's the list of changes:" & vbCrLf & changelogtotal, MsgBoxStyle.YesNo)
                    If updateyesno = MsgBoxResult.Yes Then
                        Dim wc2 As WebClient = New WebClient()
                        If CheckLink("https://dl.dropboxusercontent.com/u/23005008/candyapples/PSO2%20Alert%20Updater.exe") = "OK" Then wc.DownloadFile("https://dl.dropboxusercontent.com/u/23005008/candyapples/PSO2%20Alert%20Updater.exe", "PSO2 Alert Updater.exe")
                        If CheckLink("https://dl.dropboxusercontent.com/u/23005008/candyapples/PSO2%20Alert%20Updater.exe") <> "OK" Then wc.DownloadFile("http://arks-layer.com/tweaker/PSO2%20Alert%20Updater.exe", "PSO2 Alert Updater.exe")
                        Process.Start(Environment.CurrentDirectory & "\PSO2 Alert Updater.exe")
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Function CheckLink(ByVal Url As String) As String
        Dim req As HttpWebRequest = TryCast(WebRequest.Create(Url), HttpWebRequest)
        req.Method = "HEAD"
        Try
            Using rsp As HttpWebResponse = TryCast(req.GetResponse(), HttpWebResponse)
                Return "OK"
            End Using
        Catch ex As WebException
            Dim ReturnString As String
            ReturnString = ex.Message.ToString
            ReturnString = ReturnString.Replace("The remote server returned an error: ", "")
            Return ReturnString
        End Try
    End Function
    'Public Sub tsmLogin_Click(sender As Object, e As EventArgs) Handles tsmLogin.Click
    '    Dim credentials As IOAuthCredentials = New InMemoryCredentials
    '    Dim randomstring As String = "Xt3KRDBlHNNkBzCG1iagYL1yZlT3fVoPq3QYxBBC2"
    '    randomstring = randomstring.Replace("3", "7")
    '    credentials.ConsumerSecret = randomstring.Replace("2", "0")
    '    credentials.ConsumerKey = "2ApbGZ0dm0P48s7MzTqfRQ"
    '    If LoadSetting("OAuthToken") <> "" Then credentials.OAuthToken = LoadSetting("OAuthToken")
    '    If LoadSetting("AccessToken") <> "" Then credentials.AccessToken = LoadSetting("AccessToken")
    '    Dim auth As PinAuthorizer = New PinAuthorizer()
    '    auth.Credentials = credentials
    '    auth.UseCompression = True
    '    auth.GoToTwitterAuthorization = Function(pageLink) Process.Start(pageLink)
    '    auth.GetPin = Function() InputBox("Please enter the PIN here:", "PSO2 Alert Twitter Authentification")
    '    auth.Authorize()
    '    SaveSetting("OAuthToken", auth.Credentials.OAuthToken)
    '    SaveSetting("AccessToken", auth.Credentials.AccessToken)
    '    SaveSetting("Authorized", "Yes")
    '    twitterctx = New TwitterContext(auth)
    '    Dim tweet = twitterctx.UpdateStatus("Logging into PSO2 Alert...")
    '    NotifyIcon1.ShowBalloonTip(7000, "PSO2 Alert", ("Logged into twitter as " & tweet.User.Name), ToolTipIcon.Info)
    '    Threading.Thread.Sleep(5000)
    '    twitterctx.DestroyStatus(tweet.StatusID)
    '    tsmLogin.Text = "Logged in as " & tweet.User.Name
    '    tsmLogin.Enabled = False
    '        tsmReportEQ.Visible = True
    '        ToolStripMenuItem1.Visible = True
    'End Sub

    Private Sub tsmReportFireSwirl_Click(sender As Object, e As EventArgs) Handles tsmReportFireSwirl.Click
        Dim tweet = twitterctx.UpdateStatus("#pso2eq " & LCase(LoadSetting("ShipToQuery")) & " fire")
        Threading.Thread.Sleep(5000)
        twitterctx.DestroyStatus(tweet.StatusID)
    End Sub

    Private Sub tsmReportCaves_Click(sender As Object, e As EventArgs) Handles tsmReportCaves.Click
        Dim tweet = twitterctx.UpdateStatus("#pso2eq " & LCase(LoadSetting("ShipToQuery")) & " caves")
        Threading.Thread.Sleep(5000)
        twitterctx.DestroyStatus(tweet.StatusID)
    End Sub

    Private Sub tsmReportTunnels_Click(sender As Object, e As EventArgs) Handles tsmReportTunnels.Click
        Dim tweet = twitterctx.UpdateStatus("#pso2eq " & LCase(LoadSetting("ShipToQuery")) & " tunnels")
        Threading.Thread.Sleep(5000)
        twitterctx.DestroyStatus(tweet.StatusID)
    End Sub

    Private Sub tsmReportCity_Click(sender As Object, e As EventArgs) Handles tsmReportCity.Click
        Dim tweet = twitterctx.UpdateStatus("#pso2eq " & LCase(LoadSetting("ShipToQuery")) & " city")
        Threading.Thread.Sleep(5000)
        twitterctx.DestroyStatus(tweet.StatusID)
    End Sub

    Private Sub tsmReportCoast_Click(sender As Object, e As EventArgs) Handles tsmReportCoast.Click
        Dim tweet = twitterctx.UpdateStatus("#pso2eq " & LCase(LoadSetting("ShipToQuery")) & " coast")
        Threading.Thread.Sleep(5000)
        twitterctx.DestroyStatus(tweet.StatusID)
    End Sub

    Private Sub tsmReportDarkFalz_Click(sender As Object, e As EventArgs) Handles tsmReportDarkFalz.Click
        Dim tweet = twitterctx.UpdateStatus("#pso2eq " & LCase(LoadSetting("ShipToQuery")) & " falz")
        Threading.Thread.Sleep(5000)
        twitterctx.DestroyStatus(tweet.StatusID)
    End Sub

    Private Sub tsmReportDesert_Click(sender As Object, e As EventArgs) Handles tsmReportDesert.Click
        Dim tweet = twitterctx.UpdateStatus("#pso2eq " & LCase(LoadSetting("ShipToQuery")) & " desert")
        Threading.Thread.Sleep(5000)
        twitterctx.DestroyStatus(tweet.StatusID)
    End Sub

    Private Sub tsmReportSuperFalz_Click(sender As Object, e As EventArgs) Handles tsmReportSuperFalz.Click
        Dim tweet = twitterctx.UpdateStatus("#pso2eq " & LCase(LoadSetting("ShipToQuery")) & " elder")
        Threading.Thread.Sleep(5000)
        twitterctx.DestroyStatus(tweet.StatusID)
    End Sub

    Private Sub tsmReportFloatingContinent_Click(sender As Object, e As EventArgs) Handles tsmReportFloatingContinent.Click
        Dim tweet = twitterctx.UpdateStatus("#pso2eq " & LCase(LoadSetting("ShipToQuery")) & " chrome")
        Threading.Thread.Sleep(5000)
        twitterctx.DestroyStatus(tweet.StatusID)
    End Sub

    Private Sub tsmReportForest_Click(sender As Object, e As EventArgs) Handles tsmReportForest.Click
        Dim tweet = twitterctx.UpdateStatus("#pso2eq " & LCase(LoadSetting("ShipToQuery")) & " forest")
        Threading.Thread.Sleep(5000)
        twitterctx.DestroyStatus(tweet.StatusID)
    End Sub

    Private Sub tsmReportGeneral_Click(sender As Object, e As EventArgs) Handles tsmReportGeneral.Click
        Dim tweet = twitterctx.UpdateStatus("#pso2eq " & LCase(LoadSetting("ShipToQuery")) & " general")
        Threading.Thread.Sleep(5000)
        twitterctx.DestroyStatus(tweet.StatusID)
    End Sub

    Private Sub tsmTesting_Click(sender As Object, e As EventArgs) Handles tsmTesting.Click
        Dim tweet = twitterctx.UpdateStatus("#pso2eq " & LCase(LoadSetting("ShipToQuery")) & " impossibru")
        Threading.Thread.Sleep(5000)
        twitterctx.DestroyStatus(tweet.StatusID)
    End Sub

    Private Sub tsmReportWithWindAndRain_Click(sender As Object, e As EventArgs) Handles tsmReportWithWindAndRain.Click
        Dim tweet = twitterctx.UpdateStatus("#pso2eq " & LCase(LoadSetting("ShipToQuery")) & " rain")
        Threading.Thread.Sleep(5000)
        twitterctx.DestroyStatus(tweet.StatusID)
    End Sub

    'Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
    ' Dim typeofEQ As String = InputBox("Which type of EQ is it? (fire, amduscia, urban, vopar, falz, lilipa, naberius, superfalz, allplanets)")
    ' Dim times As String = InputBox("What times will it take place? (example: 0300-0330 is 3:00 - 3:30)")
    ' Dim tweet = twitterctx.UpdateStatus("pso2eqs2 " & LCase(LoadSetting("ShipToQuery")) & " " & typeofEQ & " " & times)
    '     Threading.Thread.Sleep(5000)
    ' 'twitterctx.DestroyStatus(tweet.StatusID)
    ' End Sub

    Private Sub picEQImage_Click(sender As Object, e As EventArgs) Handles picEQImage.Click
        tmrDisplay.Enabled = False
        Me.Opacity = 0
        Me.TopMost = False
    End Sub

    Private Sub PrimaryMonitorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrimaryMonitorToolStripMenuItem.Click
        DisplayMonitor = 1
    End Sub

    Private Sub SecondaryMonitorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SecondaryMonitorToolStripMenuItem.Click
        DisplayMonitor = 2
    End Sub

    Private Sub ArksShipFireSwirlToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ArksShipFireSwirlToolStripMenuItem.Click
        SaveSetting("Arks Ship Fire Swirl", ArksShipFireSwirlToolStripMenuItem.Checked)
    End Sub

    Private Sub BraveBorderBreakToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BraveBorderBreakToolStripMenuItem.Click
        SaveSetting("Brave Border Break", BraveBorderBreakToolStripMenuItem.Checked)
    End Sub

    Private Sub CavesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CavesToolStripMenuItem.Click
        SaveSetting("Caves", CavesToolStripMenuItem.Checked)
    End Sub

    Private Sub CoastToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CoastToolStripMenuItem.Click
        SaveSetting("Coast", CoastToolStripMenuItem.Checked)
    End Sub

    Private Sub CradleOfDarknessToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CradleOfDarknessToolStripMenuItem.Click
        SaveSetting("Cradle of Darkness", CradleOfDarknessToolStripMenuItem.Checked)
    End Sub

    Private Sub DarkFalzToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DarkFalzToolStripMenuItem.Click
        SaveSetting("Dark Falz", DarkFalzToolStripMenuItem.Checked)
    End Sub

    Private Sub DesertToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DesertToolStripMenuItem.Click
        SaveSetting("Desert", DesertToolStripMenuItem.Checked)
    End Sub

    Private Sub FloatingContinentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FloatingContinentToolStripMenuItem.Click
        SaveSetting("Floating Continent", FloatingContinentToolStripMenuItem.Checked)
    End Sub

    Private Sub ForestToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ForestToolStripMenuItem.Click
        SaveSetting("Forest", ForestToolStripMenuItem.Checked)
    End Sub

    Private Sub MerryChristmasOnIceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MerryChristmasOnIceToolStripMenuItem.Click
        SaveSetting("Merry Christmas On Ice", MerryChristmasOnIceToolStripMenuItem.Checked)
    End Sub

    Private Sub MiningBaseDefenseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MiningBaseDefenseToolStripMenuItem.Click
        SaveSetting("Mining Base Defense", MiningBaseDefenseToolStripMenuItem.Checked)
    End Sub

    Private Sub SuperFalzToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SuperFalzToolStripMenuItem.Click
        SaveSetting("Super Falz", SuperFalzToolStripMenuItem.Checked)
    End Sub

    Private Sub TrickOrTreatToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TrickOrTreatToolStripMenuItem.Click
        SaveSetting("Trick or Treat", TrickOrTreatToolStripMenuItem.Checked)
    End Sub

    Private Sub TunnelsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TunnelsToolStripMenuItem.Click
        SaveSetting("Tunnels", TunnelsToolStripMenuItem.Checked)
    End Sub

    Private Sub UrbanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UrbanToolStripMenuItem.Click
        SaveSetting("Urban", UrbanToolStripMenuItem.Checked)
    End Sub

    Private Sub WithWindAndRainToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WithWindAndRainToolStripMenuItem.Click
        SaveSetting("With With And Rain", WithWindAndRainToolStripMenuItem.Checked)
    End Sub
End Class
Public Class JSON_resultArray
    Public results() As JSON_result
End Class
Public Class JSON_result
    Public id As String
    Public from As String
    Public img As String
    Public name As String
    Public text As String
    Public until As String
    Public english As String
End Class
