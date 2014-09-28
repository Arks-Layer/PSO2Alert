
Imports System.IO
Imports System.Net
Imports System.Text.RegularExpressions

Public Class Form1
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
            source = wc.DownloadString("http://162.243.211.123/freedom/PSO2Aversion.xml")
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
                    wc.DownloadFile("http://162.243.211.123/freedom/PSO2%20Alert%20Updater.exe", "PSO2 Alert Updater.exe")
                    Process.Start(Environment.CurrentDirectory & "\PSO2 Alert Updater.exe")
                End If
            End If
        End If
    End Sub
    Private Sub InitialEQCheck()
        On Error Resume Next
        If LoadSetting("ShipToQuery") <> "Ship02" Then Exit Sub
        Dim download As New WebClient
        download.Encoding = System.Text.Encoding.UTF8
        Dim CurrentEQ As String = download.DownloadString("http://acf.me.uk/Public/PSO2EQ/pso2eq.txt")
        Dim CurrentEQOriginal As String = CurrentEQ
        'Ship02 23時30分【PSO2】第三採掘基地ダーカー接近予告
        'ShipXX (Irrelevant)
        ' 23時30分 Hour時Minute分
        '【PSO2】For PSO2 (duh)
        '第三採掘基地ダーカー接近予告 Name of EQ
        CurrentEQ = CurrentEQ.Substring(CurrentEQ.IndexOf("Ship02") + 7)
        Dim BrokenDownString As String() = CurrentEQ.Split(" ")
        Dim BrokenDownString2 As String() = BrokenDownString(0).Split("【")
        Dim EQTime As String = BrokenDownString2(0)
        EQTime = EQTime.Replace("時", ":")
        Dim EQHour As Integer = Convert.ToInt32(EQTime.Substring(0, 2))
        Dim EQHourEST As Integer
        Dim EQMinutes As String() = EQTime.Split(":")

        Dim AMPM As String = ""
        Select Case EQHour
            Case 0
                EQHourEST = 11
                AMPM = "AM"
            Case 1
                EQHourEST = 12
                AMPM = "PM"
            Case 2
                EQHourEST = 1
                AMPM = "PM"
            Case 3
                EQHourEST = 2
                AMPM = "PM"
            Case 4
                EQHourEST = 3
                AMPM = "PM"
            Case 5
                EQHourEST = 4
                AMPM = "PM"
            Case 6
                EQHourEST = 5
                AMPM = "PM"
            Case 7
                EQHourEST = 6
                AMPM = "PM"
            Case 8
                EQHourEST = 7
                AMPM = "PM"
            Case 9
                EQHourEST = 8
                AMPM = "PM"
            Case 10
                EQHourEST = 9
                AMPM = "PM"
            Case 11
                EQHourEST = 10
                AMPM = "PM"
            Case 12
                EQHourEST = 11
                AMPM = "PM"
            Case 13
                EQHourEST = 12
                AMPM = "AM"
            Case 14
                EQHourEST = 1
                AMPM = "AM"
            Case 15
                EQHourEST = 2
                AMPM = "AM"
            Case 16
                EQHourEST = 3
                AMPM = "AM"
            Case 17
                EQHourEST = 4
                AMPM = "AM"
            Case 18
                EQHourEST = 5
                AMPM = "AM"
            Case 19
                EQHourEST = 6
                AMPM = "AM"
            Case 20
                EQHourEST = 7
                AMPM = "AM"
            Case 21
                EQHourEST = 8
                AMPM = "AM"
            Case 22
                EQHourEST = 9
                AMPM = "AM"
            Case 23
                EQHourEST = 10
                AMPM = "AM"
            Case 24
                EQHourEST = 11
                AMPM = "PM"
            Case Else
                EQHourEST = 99
                AMPM = "ERROR"
        End Select
        EQTime = EQTime.Replace("分", "")
        Dim EQName As String = BrokenDownString2(1).Replace("PSO2】", "")
        Dim EQText As String = ""
        Dim EQPic As String = ""
        EQName = EQName.Replace(vbCr, "").Replace(vbLf, "")
        
        If LoadSetting("LastEQ") <> CurrentEQOriginal Then
            If LoadSetting("PlaySound") = "Yes" Then
                'MsgBox("Yo!")
                If File.Exists(LoadSetting("WAVFile")) = True Then
                    My.Computer.Audio.Play(LoadSetting("WAVFile"), AudioPlayMode.Background)
                Else
                    NotifyIcon1.ShowBalloonTip(7000, "PSO2 Alert", "WAV file not found!", ToolTipIcon.Info)
                End If
            End If
            ShowEQ("Ship 2", EQTime, EQHourEST & ":" & EQMinutes(1).Replace("分", "") & AMPM & " EDT)", EQName)
            SaveSetting("LastEQ", CurrentEQOriginal)
        End If
        SaveSetting("LastEQ", CurrentEQOriginal)
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        If LoadSetting("Beckoning Darkness") <> "" Then BeckoningDarkness.Checked = LoadSetting("Beckoning Darkness")
        If LoadSetting("Beach Wars 2") <> "" Then BeachWars2.Checked = LoadSetting("Beach Wars 2")
        If LoadSetting("Dark Falz Elder") <> "" Then DarkFalzElder.Checked = LoadSetting("Dark Falz Elder")
        If LoadSetting("Dark Falz Loser") <> "" Then DarkFalzLoser.Checked = LoadSetting("Dark Falz Loser")
        If LoadSetting("Darker Den") <> "" Then DarkerDen.Checked = LoadSetting("Darker Den")
        If LoadSetting("Interrupt Rankings") <> "" Then InterruptRankings.Checked = LoadSetting("Interrupt Rankings")
        If LoadSetting("Mecha Awakening") <> "" Then MechaAwakening.Checked = LoadSetting("Mecha Awakening")
        If LoadSetting("Planet Amduscia EQ") <> "" Then PlanetAmdusciaEQ.Checked = LoadSetting("Planet Amduscia EQ")
        If LoadSetting("Planet Lillipa EQ") <> "" Then PlanetLillipaEQ.Checked = LoadSetting("Planet Lillipa EQ")
        If LoadSetting("Planet Naberius EQ") <> "" Then PlanetNaberiusEQ.Checked = LoadSetting("Planet Naberius EQ")
        If LoadSetting("Primary Mining Base") <> "" Then PrimaryMiningBase.Checked = LoadSetting("Primary Mining Base")
        If LoadSetting("Secondary Mining Base") <> "" Then SecondaryMiningBase.Checked = LoadSetting("Secondary Mining Base")
        If LoadSetting("Shop Area Concert") <> "" Then ShopAreaConcert.Checked = LoadSetting("Shop Area Concert")
        If LoadSetting("Tertiary Mining Base") <> "" Then TertiaryMiningBase.Checked = LoadSetting("Tertiary Mining Base")
        If LoadSetting("Urban EQ") <> "" Then UrbanEQ.Checked = LoadSetting("Urban EQ")
        If LoadSetting("ThePitchBlackProvince") <> "" Then ThePitchBlackProvince.Checked = LoadSetting("ThePitchBlackProvince")

        'Uncomment to continue on multi-monitor support
        'Dim numberofmonitors As Integer = Screen.AllScreens.Length
        'If numberofmonitors = 2 Then
        ' tsmSelectMonitor.Visible = True
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
        '[AIDA] We only support ship 2 right now, so force that.
        SaveSetting("ShipToQuery", "Ship02")
        'If LoadSetting("ShipToQuery") = "" Then SaveSetting("ShipToQuery", "Ship02")
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
        On Error Resume Next
        If LoadSetting("ShipToQuery") <> "Ship02" Then Exit Sub
        Dim download As New WebClient
        download.Encoding = System.Text.Encoding.UTF8
        Dim CurrentEQ As String = download.DownloadString("http://acf.me.uk/Public/PSO2EQ/pso2eq.txt")

        Dim CurrentEQOriginal As String = CurrentEQ
        'Ship02 23時30分【PSO2】第三採掘基地ダーカー接近予告
        'ShipXX (Irrelevant)
        ' 23時30分 Hour時Minute分
        '【PSO2】For PSO2 (duh)
        '第三採掘基地ダーカー接近予告 Name of EQ
        CurrentEQ = CurrentEQ.Substring(CurrentEQ.IndexOf("Ship02") + 7)
        Dim BrokenDownString As String() = CurrentEQ.Split(" ")
        Dim BrokenDownString2 As String() = BrokenDownString(0).Split("【")
        Dim EQTime As String = BrokenDownString2(0)
        EQTime = EQTime.Replace("時", ":")
        Dim EQHour As Integer = Convert.ToInt32(EQTime.Substring(0, 2))
        Dim EQHourEST As Integer
        Dim EQMinutes As String() = EQTime.Split(":")

        Dim AMPM As String = ""
        Select Case EQHour
            Case 0
                EQHourEST = 11
                AMPM = "AM"
            Case 1
                EQHourEST = 12
                AMPM = "PM"
            Case 2
                EQHourEST = 1
                AMPM = "PM"
            Case 3
                EQHourEST = 2
                AMPM = "PM"
            Case 4
                EQHourEST = 3
                AMPM = "PM"
            Case 5
                EQHourEST = 4
                AMPM = "PM"
            Case 6
                EQHourEST = 5
                AMPM = "PM"
            Case 7
                EQHourEST = 6
                AMPM = "PM"
            Case 8
                EQHourEST = 7
                AMPM = "PM"
            Case 9
                EQHourEST = 8
                AMPM = "PM"
            Case 10
                EQHourEST = 9
                AMPM = "PM"
            Case 11
                EQHourEST = 10
                AMPM = "PM"
            Case 12
                EQHourEST = 11
                AMPM = "PM"
            Case 13
                EQHourEST = 12
                AMPM = "AM"
            Case 14
                EQHourEST = 1
                AMPM = "AM"
            Case 15
                EQHourEST = 2
                AMPM = "AM"
            Case 16
                EQHourEST = 3
                AMPM = "AM"
            Case 17
                EQHourEST = 4
                AMPM = "AM"
            Case 18
                EQHourEST = 5
                AMPM = "AM"
            Case 19
                EQHourEST = 6
                AMPM = "AM"
            Case 20
                EQHourEST = 7
                AMPM = "AM"
            Case 21
                EQHourEST = 8
                AMPM = "AM"
            Case 22
                EQHourEST = 9
                AMPM = "AM"
            Case 23
                EQHourEST = 10
                AMPM = "AM"
            Case 24
                EQHourEST = 11
                AMPM = "PM"
            Case Else
                EQHourEST = 99
                AMPM = "ERROR"
        End Select
        EQTime = EQTime.Replace("分", "")
        Dim EQName As String = BrokenDownString2(1).Replace("PSO2】", "")
        Dim EQText As String = ""
        Dim EQPic As String = ""
        EQName = EQName.Replace(vbCr, "").Replace(vbLf, "")

        If LoadSetting("LastEQ") <> CurrentEQOriginal Then
            If LoadSetting("PlaySound") = "Yes" Then
                'MsgBox("Yo!")
                If File.Exists(LoadSetting("WAVFile")) = True Then
                    My.Computer.Audio.Play(LoadSetting("WAVFile"), AudioPlayMode.Background)
                Else
                    NotifyIcon1.ShowBalloonTip(7000, "PSO2 Alert", "WAV file not found!", ToolTipIcon.Info)
                End If
            End If
            ShowEQ("Ship 2", EQTime, EQHourEST & ":" & EQMinutes(1).Replace("分", "") & AMPM & " EDT)", EQName)
            SaveSetting("LastEQ", CurrentEQOriginal)
        End If
    End Sub
    Private Sub tmrCheck_Tick(sender As Object, e As EventArgs) Handles tmrCheck.Tick
        Try

            Dim t1 As New Threading.Thread(AddressOf CheckForEQs1)
            t1.IsBackground = True
            t1.Start()

        Catch ex As Exception

        End Try
    End Sub
    Public Sub ShowEQ(ByRef Ship As String, StartTime As String, EndTime As String, EQName As String)
        Dim EQText As String = ""
        Dim EQPic As String = ""

        If EQName = "第一採掘基地ダーカー接近予告" Then
            EQName = "Primary Mining Base"
            EQText = "Emergency broadcast! Numerous Darkers are approaching the outlying regions of Lillipa's primary mining base!"
            EQPic = "http://eq.arks-layer.com/img/pso2_54200c716794b.png"
        End If
        If EQName = "第二採掘基地ダーカー接近予告" Then
            EQName = "Secondary Mining Base"
            EQText = "Emergency broadcast! Numerous Darkers are approaching the outlying regions of Lillipa's secondary mining base!"
            EQPic = "http://eq.arks-layer.com/img/pso2_54254d12494a9.png"
        End If

        If EQName = "第三採掘基地ダーカー接近予告" Then
            EQName = "Tertiary Mining Base"
            EQText = "Emergency broadcast! Darkers are approaching the outlying regions of Lillipa's tertiary mining base!"
            EQPic = "http://eq.arks-layer.com/img/pso2_54254d34756a2.png"
        End If

        If EQName = "旧マザーシップ　作戦予告" Then
            EQName = "Beckoning Darkness"
            EQText = "Emergency broadcast! A darker-infested ARKS mothership is approaching the fleet. All ARKS, prepare for large-scale combat."
            EQPic = "http://eq.arks-layer.com/img/pso2_54254b027bcb4.png"
        End If

        If EQName = "アークス船団航行物体接近予告" Then
            EQName = "Dark Falz Loser"
            EQText = "Emergency broadcast! Our readings suggest Dark Falz Loser is approaching, along with an infested former mothership."
            EQPic = "http://eq.arks-layer.com/img/pso2_54200ca52c9c0.png"
        End If
        If EQName = "アークス船団ＤＦ接近予告" Then
            EQName = "Dark Falz Elder"
            EQText = "Emergency broadcast! Dark Falz Elder is approaching the outlying regions of the ARKS fleet!"
            EQPic = "http://eq.arks-layer.com/img/pso2_54254b11c83c2.png"
        End If
        If EQName = "森林　作戦予告" Then
            EQName = "Planet Naberius EQ"
            EQText = "All ARKS are instructed to prepare for a large-scale suppression operation on Naberius."
            EQPic = "http://eq.arks-layer.com/img/pso2_54200c3e890f0.png"
        End If

        If EQName = "惑星リリーパ　作戦予告" Then
            EQName = "Planet Lillipa EQ"
            EQText = "All ARKS are instructed to prepare for a large-scale suppression operation on Lillipa."
            EQPic = "http://eq.arks-layer.com/img/pso2_54254bfe5f26a.png"
        End If

        If EQName = "砂漠　作戦予告" Then
            EQName = "Desert Guerrillas EQ"
            EQText = "All ARKS are instructed to prepare for a large-scale suppression operation on Lillipa."
            EQPic = "http://eq.arks-layer.com/img/pso2_54254bfe5f26a.png"
        End If

        If EQName = "惑星アムドゥスキア　作戦予告" Then
            EQName = "Planet Amduscia EQ"
            EQText = "All ARKS are instructed to prepare for a large-scale suppression operation on Amduscia."
            EQPic = "http://eq.arks-layer.com/img/pso2_5425b0733daaf.png"
        End If

        If EQName = "浮遊大陸　作戦予告" Then
            EQName = "Planet Amduscia EQ"
            EQText = "All ARKS are instructed to prepare for a large-scale suppression operation on Amduscia."
            EQPic = "http://eq.arks-layer.com/img/pso2_5425b0733daaf.png"
        End If

        If EQName = "インタラプトランキング予告" Then
            EQName = "Interrupt Rankings"
            EQText = "We will be holding Interrupt Rankings starting at the above time. Be sure to participate!"
            EQPic = "http://eq.arks-layer.com/img/pso2_54200bc303586.png"
        End If

        If EQName = "惑星ウォパル　作戦予告" Then
            EQName = "Beach Wars 2"
            EQText = "All ARKS are instructed to prepare for a large-scale suppression operation on Vopar."
            EQPic = "http://eq.arks-layer.com/img/pso2_54200bf904539.png"
        End If

        If EQName = "異常値観測宙域　一斉調査予告" Then
            EQName = "Darker Den"
            EQText = "The ARKS are preparing for a large-scale investigation of anomalous readings in deep space."
            EQPic = "http://eq.arks-layer.com/img/pso2_54200c44e8d8b.png"
        End If

        If EQName = "アークス船団ダーカー接近予告" Then
            EQName = "Urban EQ"
            EQText = "Emergency broadcast! Numerous Darkers are approaching the outlying regions of the ARKS fleet!"
            EQPic = "http://eq.arks-layer.com/img/pso2_54200c9706b65.png"
        End If

        If EQName = "ショップエリア　ライブ予告" Then
            EQName = "Shop Area Concert"
            EQText = "We're holding a concert in the Shop Area soon! We hope to see everyone there!"
            EQPic = "http://eq.arks-layer.com/img/pso2_5425afb646808.png"
        End If

        If EQName = "地下坑道　作戦予告" Then
            EQName = "Mecha Awakening"
            EQText = "The ARKS are preparing a large-scale operation in response to enemy activity in the Lillipan tunnels."
            EQPic = "http://eq.arks-layer.com/img/pso2_54254bc3ce565.png"
        End If

        If EQName = "白ノ領域　作戦予告" Then
            EQName = "Pitch Black Province"
            EQText = "The ARKS are preparing a large-scale operation in response to enemy activity in the Harkotan shironia area."
            EQPic = "http://eq.arks-layer.com/img/pso2_542550515edf5.png"
        End If


        If EQName = "Beckoning Darkness" And BeckoningDarkness.Checked = False Then Exit Sub
        If EQName = "Beach Wars 2" And BeachWars2.Checked = False Then Exit Sub
        If EQName = "Dark Falz Elder" And DarkFalzElder.Checked = False Then Exit Sub
        If EQName = "Dark Falz Loser" And DarkFalzLoser.Checked = False Then Exit Sub
        If EQName = "Darker Den" And DarkerDen.Checked = False Then Exit Sub
        If EQName = "Interrupt Rankings" And InterruptRankings.Checked = False Then Exit Sub
        If EQName = "Mecha Awakening" And MechaAwakening.Checked = False Then Exit Sub
        If EQName = "Planet Amduscia EQ" And PlanetAmdusciaEQ.Checked = False Then Exit Sub
        If EQName = "Planet Lillipa EQ" And PlanetLillipaEQ.Checked = False Then Exit Sub
        If EQName = "Planet Naberius EQ" And PlanetNaberiusEQ.Checked = False Then Exit Sub
        If EQName = "Primary Mining Base" And PrimaryMiningBase.Checked = False Then Exit Sub
        If EQName = "Secondary Mining Base" And SecondaryMiningBase.Checked = False Then Exit Sub
        If EQName = "Shop Area Concert" And ShopAreaConcert.Checked = False Then Exit Sub
        If EQName = "Tertiary Mining Base" And TertiaryMiningBase.Checked = False Then Exit Sub
        If EQName = "Urban EQ" And UrbanEQ.Checked = False Then Exit Sub
        If EQName = "Pitch Black Province" And ThePitchBlackProvince.Checked = False Then Exit Sub

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
            picEQImage.ImageLocation = EQPic
            Application.DoEvents()
            lblEQText.Text = EQText

            'ShowEQ("Ship 2", "", EQTime, EQHourEST & ":" & EQMinutes(1).Replace("分", "") & AMPM & " EDT)", "http://eq.arks-layer.com/img/pso2_51e3da03c6b16.png", "1", EQName)
            'Public Sub ShowEQ(ByRef Ship As String, EQText As String, StartTime As String, EndTime As String, EQImage As String, Version As String, EnglishName As String)
            lblTitle.Text = Ship & " " & EQName & " " & StartTime & "JST (" & EndTime
            If LoggingEnabled = True Then
                Dim strFile As String = Application.StartupPath & "\EQLog.txt"
                Using sw As New StreamWriter(File.Open(strFile, FileMode.Append))
                    sw.WriteLine(Ship & " " & EQName & " " & StartTime & "JST (" & EndTime & vbCrLf)
                End Using
            End If

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

    Private Sub lblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        tmrDisplay.Enabled = False
        Me.Opacity = 0
        Me.TopMost = False
    End Sub

    Private Sub ShowRecentEQs()
        If LoadSetting("ShipToQuery") <> "Ship02" Then Exit Sub
        Dim download As New WebClient
        download.Encoding = System.Text.Encoding.UTF8
        Dim CurrentEQ As String = download.DownloadString("http://acf.me.uk/Public/PSO2EQ/pso2eq.txt")
        'Ship02 23時30分【PSO2】第三採掘基地ダーカー接近予告
        'ShipXX (Irrelevant)
        ' 23時30分 Hour時Minute分
        '【PSO2】For PSO2 (duh)
        '第三採掘基地ダーカー接近予告 Name of EQ
        CurrentEQ = CurrentEQ.Substring(CurrentEQ.IndexOf("Ship02") + 7)
        Dim BrokenDownString As String() = CurrentEQ.Split(" ")
        Dim BrokenDownString2 As String() = BrokenDownString(0).Split("【")
        Dim EQTime As String = BrokenDownString2(0)
        EQTime = EQTime.Replace("時", ":")
        Dim EQHour As Integer = Convert.ToInt32(EQTime.Substring(0, 2))
        Dim EQHourEST As Integer
        Dim EQMinutes As String() = EQTime.Split(":")

        Dim AMPM As String = ""
        Select Case EQHour
            Case 0
                EQHourEST = 11
                AMPM = "AM"
            Case 1
                EQHourEST = 12
                AMPM = "PM"
            Case 2
                EQHourEST = 1
                AMPM = "PM"
            Case 3
                EQHourEST = 2
                AMPM = "PM"
            Case 4
                EQHourEST = 3
                AMPM = "PM"
            Case 5
                EQHourEST = 4
                AMPM = "PM"
            Case 6
                EQHourEST = 5
                AMPM = "PM"
            Case 7
                EQHourEST = 6
                AMPM = "PM"
            Case 8
                EQHourEST = 7
                AMPM = "PM"
            Case 9
                EQHourEST = 8
                AMPM = "PM"
            Case 10
                EQHourEST = 9
                AMPM = "PM"
            Case 11
                EQHourEST = 10
                AMPM = "PM"
            Case 12
                EQHourEST = 11
                AMPM = "PM"
            Case 13
                EQHourEST = 12
                AMPM = "AM"
            Case 14
                EQHourEST = 1
                AMPM = "AM"
            Case 15
                EQHourEST = 2
                AMPM = "AM"
            Case 16
                EQHourEST = 3
                AMPM = "AM"
            Case 17
                EQHourEST = 4
                AMPM = "AM"
            Case 18
                EQHourEST = 5
                AMPM = "AM"
            Case 19
                EQHourEST = 6
                AMPM = "AM"
            Case 20
                EQHourEST = 7
                AMPM = "AM"
            Case 21
                EQHourEST = 8
                AMPM = "AM"
            Case 22
                EQHourEST = 9
                AMPM = "AM"
            Case 23
                EQHourEST = 10
                AMPM = "AM"
            Case 24
                EQHourEST = 11
                AMPM = "PM"
            Case Else
                EQHourEST = 99
                AMPM = "ERROR"
        End Select
        EQTime = EQTime.Replace("分", "")
        Dim EQName As String = BrokenDownString2(1).Replace("PSO2】", "")
        Dim EQText As String = ""
        Dim EQPic As String = ""
        EQName = EQName.Replace(vbCr, "").Replace(vbLf, "")
        ShowEQ("Ship 2", EQTime, EQHourEST & ":" & EQMinutes(1).Replace("分", "") & AMPM & " EDT)", EQName)
        'SendMessage("[EQ Notice] " & EQName & " at " & EQTime & "JST (" & EQHourEST & ":" & EQMinutes(1).Replace("分", "") & AMPM & " EDT)")
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
            source = wc.DownloadString("http://162.243.211.123/freedom/PSO2Aversion.xml")

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
                        wc.DownloadFile("http://162.243.211.123/freedom/PSO2A%20Updater.exe", "PSO2 Alert Updater.exe")
                        Process.Start(Environment.CurrentDirectory & "\PSO2 Alert Updater.exe")
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    
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

    Private Sub UrbanEQ_Click(sender As Object, e As EventArgs) Handles UrbanEQ.Click
        SaveSetting("Urban EQ", UrbanEQ.Checked)
    End Sub

    Private Sub TertiaryMiningBase_Click(sender As Object, e As EventArgs) Handles TertiaryMiningBase.Click
        SaveSetting("Tertiary Mining Base", TertiaryMiningBase.Checked)
    End Sub

    Private Sub ShopAreaConcert_Click(sender As Object, e As EventArgs) Handles ShopAreaConcert.Click
        SaveSetting("Shop Area Concert", ShopAreaConcert.Checked)
    End Sub

    Private Sub SecondaryMiningBase_Click(sender As Object, e As EventArgs) Handles SecondaryMiningBase.Click
        SaveSetting("Secondary Mining Base", SecondaryMiningBase.Checked)
    End Sub

    Private Sub PrimaryMiningBase_Click(sender As Object, e As EventArgs) Handles PrimaryMiningBase.Click
        SaveSetting("Primary Mining Base", PrimaryMiningBase.Checked)
    End Sub

    Private Sub PlanetNaberiusEQ_Click(sender As Object, e As EventArgs) Handles PlanetNaberiusEQ.Click
        SaveSetting("Planet Naberius EQ", PlanetNaberiusEQ.Checked)
    End Sub

    Private Sub PlanetLillipaEQ_Click(sender As Object, e As EventArgs) Handles PlanetLillipaEQ.Click
        SaveSetting("Planet Lillipa EQ", PlanetLillipaEQ.Checked)
    End Sub

    Private Sub PlanetAmdusciaEQ_Click(sender As Object, e As EventArgs) Handles PlanetAmdusciaEQ.Click
        SaveSetting("Planet Amduscia EQ", PlanetAmdusciaEQ.Checked)
    End Sub

    Private Sub MechaAwakening_Click(sender As Object, e As EventArgs) Handles MechaAwakening.Click
        SaveSetting("Mecha Awakening", MechaAwakening.Checked)
    End Sub

    Private Sub InterruptRankings_Click(sender As Object, e As EventArgs) Handles InterruptRankings.Click
        SaveSetting("Interrupt Rankings", InterruptRankings.Checked)
    End Sub

    Private Sub DarkerDen_Click(sender As Object, e As EventArgs) Handles DarkerDen.Click
        SaveSetting("Darker Den", DarkerDen.Checked)
    End Sub

    Private Sub DarkFalzLoser_Click(sender As Object, e As EventArgs) Handles DarkFalzLoser.Click
        SaveSetting("Dark Falz Loser", DarkFalzLoser.Checked)
    End Sub

    Private Sub DarkFalzElder_Click(sender As Object, e As EventArgs) Handles DarkFalzElder.Click
        SaveSetting("Dark Falz Elder", DarkFalzElder.Checked)
    End Sub

    Private Sub BeckoningDarkness_Click(sender As Object, e As EventArgs) Handles BeckoningDarkness.Click
        SaveSetting("Beckoning Darkness", BeckoningDarkness.Checked)
    End Sub

    Private Sub BeachWars2_Click(sender As Object, e As EventArgs) Handles BeachWars2.Click
        SaveSetting("Beach Wars 2", BeachWars2.Checked)
    End Sub

    Private Sub ThePitchBlackProvince_Click(sender As Object, e As EventArgs) Handles ThePitchBlackProvince.Click
        SaveSetting("The Pitch Black Province", ThePitchBlackProvince.Checked)
    End Sub
End Class