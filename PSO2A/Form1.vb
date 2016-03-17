'------------------------------------------------------------------------------
' PSO2 Alert - A Desktop EQ Notification System for PSO2.
' Thanks for taking a look at this code.
' Feel free to submit bugfixes/improvements to 
' https://github.com/Arks-Layer/PSO2Alert/
' 
' Take care, and have fun in everything you do. - AIDA
' Program uses the GNU GENERAL PUBLIC LICENSE
'------------------------------------------------------------------------------
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Threading

Public Class Form1
    ' TODO: Should be using Using statements with WebClient and such

    ' This can be set up to be changed at any time
    Private Shared localTimeZone As TimeZoneInfo = TimeZoneInfo.Local

    Public LoggingEnabled As Boolean = False
    Public DisplayMonitor As Integer = 1
    Dim _freedomUrl As String = "http://162.243.211.123/freedom/"

    Private Sub Form1_Click(sender As Object, e As EventArgs) Handles Me.Click
        tmrDisplay.Enabled = False
        Me.Opacity = 0
        Me.TopMost = False
    End Sub

    Private Sub CheckForUpdates(state As Object)
        Dim localVersion As String = My.Application.Info.Version.ToString
        Dim wc As New Net.WebClient
        wc.Proxy = Nothing
        Dim source As String = String.Empty
        If File.Exists(Application.StartupPath & "\PSO2 Alert Updater.exe") Then File.Delete(Application.StartupPath & "\PSO2 Alert Updater.exe")
        Try
            _freedomUrl = wc.DownloadString("http://arks-layer.com/freedom.txt")
            If _freedomUrl.Contains("freedom") = False Then
                _freedomUrl = "http://162.243.211.123/freedom/"
            End If
            source = wc.DownloadString(_freedomUrl & "PSO2Aversion.xml")
        Catch ex As Exception
            NotifyIcon1.ShowBalloonTip(7000, "", "PSO2 Alert error: Could not check for updates!", ToolTipIcon.Info)
            Thread.Sleep(7000)
        End Try

        If source.Contains("<VersionHistory>") = True Then

            Dim xm As New Xml.XmlDocument
            xm.LoadXml(source)

            Dim currentVersion As String = xm.SelectSingleNode("//CurrentVersion").ChildNodes(0).InnerText.Trim

            ' TODO: this one is never used?
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
                If Not String.IsNullOrEmpty(changelog2) Then changelogtotal += vbCrLf & changelog2
                If Not String.IsNullOrEmpty(changelog3) Then changelogtotal += vbCrLf & changelog3
                If Not String.IsNullOrEmpty(changelog4) Then changelogtotal += vbCrLf & changelog4
                If Not String.IsNullOrEmpty(changelog5) Then changelogtotal += vbCrLf & changelog5
                If Not String.IsNullOrEmpty(changelog6) Then changelogtotal += vbCrLf & changelog6
                If Not String.IsNullOrEmpty(changelog7) Then changelogtotal += vbCrLf & changelog7
                If Not String.IsNullOrEmpty(changelog8) Then changelogtotal += vbCrLf & changelog8
                If Not String.IsNullOrEmpty(changelog9) Then changelogtotal += vbCrLf & changelog9
                If Not String.IsNullOrEmpty(changelog10) Then changelogtotal += vbCrLf & changelog10
                Dim updateyesno As MsgBoxResult = MsgBox("You are using an outdated version of PSO2 Alert. You have version " & My.Application.Info.Version.ToString & " and the latest version is " & currentVersion & ". Would you like to download the latest version?" & vbCrLf & vbCrLf & "Here's the list of changes:" & vbCrLf & changelogtotal, MsgBoxStyle.YesNo)
                If updateyesno = MsgBoxResult.Yes Then
                    wc.DownloadFile(_freedomUrl & "PSO2%20Alert%20Updater.exe", "PSO2 Alert Updater.exe")
                    Process.Start(Environment.CurrentDirectory & "\PSO2 Alert Updater.exe")
                End If
            End If
        End If
    End Sub

    Private Sub InitialEQCheck(state As Object)
        If RegKey.GetValue(Of String)(RegKey.ShipToQuery) <> "Ship02" Then Exit Sub

        Dim download As New WebClient With {.Encoding = Encoding.UTF8}
        Try
            Dim CurrentEQOriginal As String = download.DownloadString("http://acf.me.uk/Public/PSO2EQ/pso2eq.txt")

            If CurrentEQOriginal = "" Then
                RegKey.SetValue(RegKey.LastEQ, CurrentEQOriginal)
                NotifyIcon1.ShowBalloonTip(5000, "", "Looks like something is wrong with EQ announcements. It'll be fixed soon!", ToolTipIcon.Error)
                Exit Sub
            End If
            Dim CurrentEQ = CurrentEQOriginal.Remove(CurrentEQOriginal.IndexOf("分"c)).Substring(CurrentEQOriginal.IndexOf(" "c))
            Dim tempEQTime As String() = CurrentEQ.Split("時"c)
            Dim localEQDateIn = Helper.JapanTimeToLocal(Convert.ToInt32(tempEQTime(0)), Convert.ToInt32(tempEQTime(1)), localTimeZone)

            If RegKey.GetValue(Of String)(RegKey.LastEQ) <> CurrentEQOriginal Then
                If RegKey.GetValue(Of String)(RegKey.PlaySound) = "Yes" Then
                    If File.Exists(RegKey.GetValue(Of String)(RegKey.WAVFile)) = True Then
                        My.Computer.Audio.Play(RegKey.GetValue(Of String)(RegKey.WAVFile), AudioPlayMode.Background)
                    Else
                        NotifyIcon1.ShowBalloonTip(7000, "PSO2 Alert", "WAV file not found!", ToolTipIcon.Info)
                    End If
                End If

                Dim EQName = CurrentEQOriginal.Substring(CurrentEQOriginal.IndexOf("】"c) + 1)

                ShowEQ("Ship 2", tempEQTime(0) & ":" & tempEQTime(1), localEQDateIn.ToString("t"), EQName)
                RegKey.SetValue(RegKey.LastEQ, CurrentEQOriginal)
            End If
        Catch ex As Exception
            RegKey.SetValue(RegKey.LastEQ, "Broken")
            NotifyIcon1.ShowBalloonTip(5000, "", "Looks like something is wrong with EQ announcements. It'll be fixed soon!", ToolTipIcon.Error)
            Exit Sub
        End Try
        RegKey.SetValue(RegKey.LastEQ, download.DownloadString("http://acf.me.uk/Public/PSO2EQ/pso2eq.txt"))
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not String.IsNullOrEmpty(RegKey.GetValue(Of String)(RegKey.BeckoningDarkness)) Then BeckoningDarkness.Checked = Convert.ToBoolean(RegKey.GetValue(Of String)(RegKey.BeckoningDarkness))
        If Not String.IsNullOrEmpty(RegKey.GetValue(Of String)(RegKey.BeachWars2)) Then BeachWars2.Checked = Convert.ToBoolean(RegKey.GetValue(Of String)(RegKey.BeachWars2))
        If Not String.IsNullOrEmpty(RegKey.GetValue(Of String)(RegKey.DarkFalzElder)) Then DarkFalzElder.Checked = Convert.ToBoolean(RegKey.GetValue(Of String)(RegKey.DarkFalzElder))
        If Not String.IsNullOrEmpty(RegKey.GetValue(Of String)(RegKey.DarkFalzLoser)) Then DarkFalzLoser.Checked = Convert.ToBoolean(RegKey.GetValue(Of String)(RegKey.DarkFalzLoser))
        If Not String.IsNullOrEmpty(RegKey.GetValue(Of String)(RegKey.DarkerDen)) Then DarkerDen.Checked = Convert.ToBoolean(RegKey.GetValue(Of String)(RegKey.DarkerDen))
        If Not String.IsNullOrEmpty(RegKey.GetValue(Of String)(RegKey.InterruptRankings)) Then InterruptRankings.Checked = Convert.ToBoolean(RegKey.GetValue(Of String)(RegKey.InterruptRankings))
        If Not String.IsNullOrEmpty(RegKey.GetValue(Of String)(RegKey.MechaAwakening)) Then MechaAwakening.Checked = Convert.ToBoolean(RegKey.GetValue(Of String)(RegKey.MechaAwakening))
        If Not String.IsNullOrEmpty(RegKey.GetValue(Of String)(RegKey.PlanetAmdusciaEQ)) Then PlanetAmdusciaEQ.Checked = Convert.ToBoolean(RegKey.GetValue(Of String)(RegKey.PlanetAmdusciaEQ))
        If Not String.IsNullOrEmpty(RegKey.GetValue(Of String)(RegKey.PlanetLillipaEQ)) Then PlanetLillipaEQ.Checked = Convert.ToBoolean(RegKey.GetValue(Of String)(RegKey.PlanetLillipaEQ))
        If Not String.IsNullOrEmpty(RegKey.GetValue(Of String)(RegKey.PlanetNaberiusEQ)) Then PlanetNaberiusEQ.Checked = Convert.ToBoolean(RegKey.GetValue(Of String)(RegKey.PlanetNaberiusEQ))
        If Not String.IsNullOrEmpty(RegKey.GetValue(Of String)(RegKey.PrimaryMiningBase)) Then PrimaryMiningBase.Checked = Convert.ToBoolean(RegKey.GetValue(Of String)(RegKey.PrimaryMiningBase))
        If Not String.IsNullOrEmpty(RegKey.GetValue(Of String)(RegKey.SecondaryMiningBase)) Then SecondaryMiningBase.Checked = Convert.ToBoolean(RegKey.GetValue(Of String)(RegKey.SecondaryMiningBase))
        If Not String.IsNullOrEmpty(RegKey.GetValue(Of String)(RegKey.ShopAreaConcert)) Then ShopAreaConcert.Checked = Convert.ToBoolean(RegKey.GetValue(Of String)(RegKey.ShopAreaConcert))
        If Not String.IsNullOrEmpty(RegKey.GetValue(Of String)(RegKey.TertiaryMiningBase)) Then TertiaryMiningBase.Checked = Convert.ToBoolean(RegKey.GetValue(Of String)(RegKey.TertiaryMiningBase))
        If Not String.IsNullOrEmpty(RegKey.GetValue(Of String)(RegKey.UrbanEQ)) Then UrbanEQ.Checked = Convert.ToBoolean(RegKey.GetValue(Of String)(RegKey.UrbanEQ))
        If Not String.IsNullOrEmpty(RegKey.GetValue(Of String)(RegKey.ThePitchBlackProvince)) Then ThePitchBlackProvince.Checked = Convert.ToBoolean(RegKey.GetValue(Of String)(RegKey.ThePitchBlackProvince))
        If Not String.IsNullOrEmpty(RegKey.GetValue(Of String)(RegKey.AttackonMagatsu)) Then AttackOnMagatsu.Checked = Convert.ToBoolean(RegKey.GetValue(Of String)(RegKey.AttackonMagatsu))

        'Uncomment to continue on multi-monitor support
        'Dim numberofmonitors As Integer = Screen.AllScreens.Length
        'If numberofmonitors = 2 Then
        ' tsmSelectMonitor.Visible = True
        ' End If

        ThreadPool.QueueUserWorkItem(AddressOf CheckForUpdates, Nothing)

        NotifyIcon1.Visible = False
        If RegKey.GetValue(Of String)(RegKey.PlaySound) = "Yes" Then
            If File.Exists(RegKey.GetValue(Of String)(RegKey.WAVFile)) = True Then
                tsmSound.Checked = True
            End If
        End If
        If RegKey.GetValue(Of String)(RegKey.StartWithWindows) = "Yes" Then tsmStartWithWindows.Checked = True
        '[AIDA] We only support ship 2 right now, so force that.
        RegKey.SetValue(RegKey.ShipToQuery, "Ship02")
        'If RegKey.GetValue(of string)(RegKey.ShipToQuery) = "" Then RegKey.SetValue(RegKey.ShipToQuery, "Ship02")
        tscShip.Text = RegKey.GetValue(Of String)(RegKey.ShipToQuery)
        'tsmDebugShowEQ.Visible = True
        'If My.Settings.Ship = "" Then My.Settings.Ship = "Ship02"
        Me.Opacity = 0
        NotifyIcon1.Visible = True
        tsmVersion.Text = "PSO2 Alert v" & My.Application.Info.Version.ToString
        NotifyIcon1.ShowBalloonTip(7001, "", "PSO2 Alert v" & My.Application.Info.Version.ToString & " is now ready and waiting for EQ alerts", ToolTipIcon.Info)
        ThreadPool.QueueUserWorkItem(AddressOf InitialEQCheck, Nothing)
    End Sub

    Private Sub CheckForEQs1(state As Object)
        If RegKey.GetValue(Of String)(RegKey.ShipToQuery) <> "Ship02" Then Exit Sub

        Dim download As New WebClient With {.Encoding = Encoding.UTF8}
        Try
            Dim CurrentEQOriginal As String = download.DownloadString("http://acf.me.uk/Public/PSO2EQ/pso2eq.txt")
            If RegKey.GetValue(Of String)(RegKey.LastEQ) = CurrentEQOriginal Then Exit Sub

            If CurrentEQOriginal = "" Then
                RegKey.SetValue(RegKey.LastEQ, CurrentEQOriginal)
                NotifyIcon1.ShowBalloonTip(5000, "", "Looks like something is wrong with EQ announcements. It'll be fixed soon!", ToolTipIcon.Error)
                Exit Sub
            End If
            Dim CurrentEQ = CurrentEQOriginal.Remove(CurrentEQOriginal.IndexOf("分"c)).Substring(CurrentEQOriginal.IndexOf(" "c))
            Dim tempEQTime As String() = CurrentEQ.Split("時"c)
            Dim localEQDateIn = Helper.JapanTimeToLocal(Convert.ToInt32(tempEQTime(0)), Convert.ToInt32(tempEQTime(1)), localTimeZone)

            Dim EQName = CurrentEQOriginal.Substring(CurrentEQOriginal.IndexOf("】"c) + 1)

            If RegKey.GetValue(Of String)(RegKey.LastEQ) <> CurrentEQOriginal Then
                If RegKey.GetValue(Of String)(RegKey.PlaySound) = "Yes" Then
                    If File.Exists(RegKey.GetValue(Of String)(RegKey.WAVFile)) = True Then
                        My.Computer.Audio.Play(RegKey.GetValue(Of String)(RegKey.WAVFile), AudioPlayMode.Background)
                    Else
                        NotifyIcon1.ShowBalloonTip(7000, "PSO2 Alert", "WAV file not found!", ToolTipIcon.Info)
                    End If
                End If

                ShowEQ("Ship 2", tempEQTime(0) & ":" & tempEQTime(1), localEQDateIn.ToString("t"), EQName)
                RegKey.SetValue(RegKey.LastEQ, CurrentEQOriginal)
            End If
        Catch ex As Exception
            If RegKey.GetValue(Of String)(RegKey.LastEQ) = "Broken" Then Exit Sub
            RegKey.SetValue(RegKey.LastEQ, "Broken")
            NotifyIcon1.ShowBalloonTip(5000, "", "Looks like something is wrong with EQ announcements. It'll be fixed soon!", ToolTipIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub tmrCheck_Tick(sender As Object, e As EventArgs) Handles tmrCheck.Tick
        ThreadPool.QueueUserWorkItem(AddressOf CheckForEQs1, Nothing)
    End Sub

    Public Sub ShowEQ(ByRef Ship As String, JPTime As String, LocalTime As String, EQName As String)
        Dim EQText As String = ""
        Dim EQPic As String = ""
        EQName = EQName.Replace(vbLf, "")
        Select Case EQName

            Case "『禍津』出現予告"
                If Not AttackonMagatsu.Checked Then Exit Sub
                EQName = RegKey.AttackonMagatsu
                EQText = "Emergency broadcast! Magatsu is approaching the outlying region of Shironia!"
                EQPic = "http://arks-layer.com/eqimg/magatsu.png"

            Case "第一採掘基地ダーカー接近予告"
                If Not PrimaryMiningBase.Checked Then Exit Sub
                EQName = RegKey.PrimaryMiningBase
                EQText = "Emergency broadcast! Numerous Darkers are approaching the outlying regions of Lillipa's primary mining base!"
                EQPic = "http://arks-layer.com/eqimg/pso2_54200c716794b.png"

            Case "第二採掘基地ダーカー接近予告"
                If Not SecondaryMiningBase.Checked Then Exit Sub
                EQName = RegKey.SecondaryMiningBase
                EQText = "Emergency broadcast! Numerous Darkers are approaching the outlying regions of Lillipa's secondary mining base!"
                EQPic = "http://arks-layer.com/eqimg/pso2_54254d12494a9.png"

            Case "第三採掘基地ダーカー接近予告"
                If Not TertiaryMiningBase.Checked Then Exit Sub
                EQName = RegKey.TertiaryMiningBase
                EQText = "Emergency broadcast! Darkers are approaching the outlying regions of Lillipa's tertiary mining base!"
                EQPic = "http://arks-layer.com/eqimg/pso2_54254d34756a2.png"

            Case "旧マザーシップ　作戦予告"
                If Not BeckoningDarkness.Checked Then Exit Sub
                EQName = RegKey.BeckoningDarkness
                EQText = "Emergency broadcast! A darker-infested ARKS mothership is approaching the fleet. All ARKS, prepare for large-scale combat."
                EQPic = "http://arks-layer.com/eqimg/pso2_54254b027bcb4.png"

                'TODO: Remove "ＤＦ【敗者" but not now so it won't break if something goes wrong
            Case "アークス船団航行物体接近予告", "ＤＦ【敗者】接近予告", "ＤＦ【敗者"
                If Not DarkFalzLoser.Checked Then Exit Sub
                EQName = RegKey.DarkFalzLoser
                EQText = "Emergency broadcast! Our readings suggest Dark Falz Loser is approaching, along with an infested former mothership."
                EQPic = "http://arks-layer.com/eqimg/pso2_54200ca52c9c0.png"

                'TODO: Remove "ＤＦ【巨躯" but not now so it won't break if something goes wrong
            Case "アークス船団ＤＦ接近予告", "ＤＦ【巨躯", "ＤＦ【巨躯】接近予告"
                If Not DarkFalzElder.Checked Then Exit Sub
                EQName = RegKey.DarkFalzElder
                EQText = "Emergency broadcast! Dark Falz Elder is approaching the outlying regions of the ARKS fleet!"
                EQPic = "http://arks-layer.com/eqimg/pso2_54254b11c83c2.png"

            Case "惑星ナベリウス 作戦予告"
                If Not PlanetNaberiusEQ.Checked Then Exit Sub
                EQName = RegKey.PlanetNaberiusEQ
                EQText = "All ARKS are instructed to prepare for a large-scale suppression operation on Naberius."
                EQPic = "http://arks-layer.com/eqimg/pso2_54254bfe5f26a.png"

            Case "森林　作戦予告"
                EQName = "Naberius: Forest EQ"
                EQText = "All ARKS are instructed to prepare for a large-scale suppression operation on Naberius."
                EQPic = "http://arks-layer.com/eqimg/pso2_54200c3e890f0.png"

            Case "凍土　作戦予告"
                EQName = "Naberius: Tundra EQ"
                EQText = "All ARKS are instructed to prepare for a large-scale suppression operation on Naberius."
                EQPic = "http://arks-layer.com/eqimg/pso2_54200c3e890f0.png"

            Case "遺跡 作戦予告"
                EQName = "Naberius: Ruins EQ"
                EQText = "All ARKS are instructed to prepare for a large-scale suppression operation on Naberius."
                EQPic = "http://arks-layer.com/eqimg/pso2_54200c3e890f0.png"

            Case "惑星リリーパ　作戦予告"
                If Not PlanetLillipaEQ.Checked Then Exit Sub
                EQName = RegKey.PlanetLillipaEQ
                EQText = "All ARKS are instructed to prepare for a large-scale suppression operation on Lillipa."
                EQPic = "http://arks-layer.com/eqimg/pso2_54254bfe5f26a.png"


            Case "火山洞窟　作戦予告"
                EQName = "Volcanic Caves"
                EQText = "All ARKS are instructed to prepare for a large-scale suppression operation on Lillipa."
                EQPic = "http://arks-layer.com/eqimg/pso2_54254bfe5f26a.png"

            Case "砂漠　作戦予告"
                EQName = "Lillipa: Desert EQ"
                EQText = "All ARKS are instructed to prepare for a large-scale suppression operation on Lillipa."
                EQPic = "http://arks-layer.com/eqimg/pso2_54254bfe5f26a.png"

            Case "採掘場跡　作戦予告"
                EQName = "Lillipa: Quarry EQ"
                EQText = "All ARKS are instructed to prepare for a large-scale suppression operation on Lillipa."
                EQPic = "http://arks-layer.com/eqimg/pso2_54254bfe5f26a.png"

            Case "惑星アムドゥスキア　作戦予告"
                If Not PlanetAmdusciaEQ.Checked Then Exit Sub
                EQName = RegKey.PlanetAmdusciaEQ
                EQText = "All ARKS are instructed to prepare for a large-scale suppression operation on Amduscia."
                EQPic = "http://arks-layer.com/eqimg/pso2_5425b0733daaf.png"

            Case "浮遊大陸　作戦予告"
                EQName = "Amduscia: Skyscape EQ"
                EQText = "All ARKS are instructed to prepare for a large-scale suppression operation on Amduscia."
                EQPic = "http://arks-layer.com/eqimg/pso2_5425b0733daaf.png"

            Case "龍祭壇　作戦予告"
                EQName = "Amduscia: Sanctum EQ"
                EQText = "All ARKS are instructed to prepare for a large-scale suppression operation on Amduscia."
                EQPic = "http://arks-layer.com/eqimg/pso2_5425b0733daaf.png"

            Case "インタラプトランキング予告"
                If Not InterruptRankings.Checked Then Exit Sub
                EQName = RegKey.InterruptRankings
                EQText = "We will be holding Interrupt Rankings starting at the above time. Be sure to participate!"
                EQPic = "http://arks-layer.com/eqimg/pso2_54200bc303586.png"

            Case "惑星ウォパル　作戦予告"
                EQName = "Planet Vopar EQ"
                EQText = "All ARKS are instructed to prepare for a large-scale suppression operation on Vopar."
                EQPic = "http://arks-layer.com/eqimg/pso2_54200bf904539.png"

            Case "海岸　作戦予告"
                EQName = "Vopar: Coast EQ"
                EQText = "All ARKS are instructed to prepare for a large-scale suppression operation on Vopar."
                EQPic = "http://arks-layer.com/eqimg/pso2_54200bf904539.png"

            Case "海底 作戦予告"
                EQName = "Vopar: Seabed EQ"
                EQText = "All ARKS are instructed to prepare for a large-scale suppression operation on Vopar."
                EQPic = "http://arks-layer.com/eqimg/pso2_54200bf904539.png"

            Case "浮上施設　作戦予告"
                EQName = "Vopar: Floating Facility EQ"
                EQText = "All ARKS are instructed to prepare for a large-scale suppression operation on Vopar."
                EQPic = "http://arks-layer.com/eqimg/pso2_54200bf904539.png"

            Case "異常値観測宙域　一斉調査予告"
                If Not DarkerDen.Checked Then Exit Sub
                EQName = RegKey.DarkerDen
                EQText = "The ARKS are preparing for a large-scale investigation of anomalous readings in deep space."
                EQPic = "http://arks-layer.com/eqimg/pso2_54200c44e8d8b.png"

            Case "アークス船団ダーカー接近予告"
                EQName = "ARKS Ship Urban EQ"
                EQText = "Emergency broadcast! Numerous Darkers are approaching the outlying regions of the ARKS fleet!"
                EQPic = "http://arks-layer.com/eqimg/pso2_54200c9706b65.png"

            Case "ショップエリア　ライブ予告"
                If Not ShopAreaConcert.Checked Then Exit Sub
                EQName = RegKey.ShopAreaConcert
                EQText = "We're holding a concert in the Shop Area soon! We hope to see everyone there!"
                EQPic = "http://arks-layer.com/eqimg/pso2_5425afb646808.png"

            Case "地下坑道　作戦予告"
                EQName = "Lillipa: Subterranean Tunnels EQ"
                EQText = "The ARKS are preparing a large-scale operation in response to enemy activity in the Lillipan tunnels."
                EQPic = "http://arks-layer.com/eqimg/pso2_54254bc3ce565.png"

            Case "白ノ領域　作戦予告"
                EQName = "Harkotan: Shironia EQ"
                EQText = "The ARKS are preparing a large-scale operation in response to enemy activity in the Harkotan shironia area."
                EQPic = "http://arks-layer.com/eqimg/pso2_542550515edf5.png"

            Case "惑星ハルコタン 作戦予告"
                EQName = "Planet Harkotan EQ"
                EQText = "The ARKS are preparing a large-scale operation in response to enemy activity in the Harkotan shironia area."
                EQPic = "http://arks-layer.com/eqimg/pso2_542550515edf5.png"
        End Select

        If EQName = RegKey.PlanetNaberiusEQ And PlanetNaberiusEQ.Checked = False Then Exit Sub
        If EQName = RegKey.BeachWars2 And BeachWars2.Checked = False Then Exit Sub
        If EQName = RegKey.MechaAwakening And MechaAwakening.Checked = False Then Exit Sub
        If EQName = RegKey.UrbanEQ And UrbanEQ.Checked = False Then Exit Sub
        If EQName = "Pitch Black Province" And ThePitchBlackProvince.Checked = False Then Exit Sub

        ' TODO: This isn't quite right
        If Me.InvokeRequired Then
            Me.Invoke(New Action(Of String)(AddressOf ShowRecentEQs), Text)
        Else
            Me.Opacity = 100
            Me.TopMost = True

            If DisplayMonitor = 1 Then
                Dim x = Screen.PrimaryScreen.WorkingArea.Width - Me.Width
                Dim y = Screen.PrimaryScreen.WorkingArea.Height - (Me.Height - 1)
                Me.Location = New Point(x, y)
            End If
            If DisplayMonitor = 2 Then
                Dim x = 0 - Me.Width
                Dim y = Screen.AllScreens(1).Bounds.Height - (Me.Height - 10)
                Me.Location = New Point(x, y)
            End If

            picEQImage.ImageLocation = EQPic
            Application.DoEvents()
            lblEQText.Text = EQText
            lblTitle.Text = Ship & " " & EQName & " " & JPTime & "JST (" & LocalTime

            ' TODO: As of yet this never gets called because nothing sets LoggingEnabled
            If LoggingEnabled = True Then
                Dim strFile As String = Application.StartupPath & "\EQLog.txt"
                Using sw As New StreamWriter(File.Open(strFile, FileMode.Append))
                    sw.WriteLine(Ship & " " & EQName & " " & JPTime & "JST (" & LocalTime & vbCrLf)
                End Using
            End If

            Application.DoEvents()
            tmrDisplay.Enabled = True
        End If
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
            Thread.Sleep(50)
        Next
        Me.TopMost = False
        tmrDisplay.Enabled = False
    End Sub

    Private Sub lblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        tmrDisplay.Enabled = False
        Me.Opacity = 0
        Me.TopMost = False
    End Sub

    Private Sub ShowRecentEQs(state As Object)
        If RegKey.GetValue(Of String)(RegKey.ShipToQuery) <> "Ship02" Then Exit Sub

        Dim download As New WebClient With {.Encoding = Encoding.UTF8}
        Try
            Dim CurrentEQOriginal As String = download.DownloadString("http://acf.me.uk/Public/PSO2EQ/pso2eq.txt")
            If CurrentEQOriginal = "" Then
                RegKey.SetValue(RegKey.LastEQ, CurrentEQOriginal)
                NotifyIcon1.ShowBalloonTip(5000, "", "Looks like something is wrong with EQ announcements. It'll be fixed soon!", ToolTipIcon.Error)
                Exit Sub
            End If
            Dim CurrentEQ = CurrentEQOriginal.Remove(CurrentEQOriginal.IndexOf("分"c)).Substring(CurrentEQOriginal.IndexOf(" "c))
            Dim tempEQTime As String() = CurrentEQ.Split("時"c)
            Dim localEQDateIn = Helper.JapanTimeToLocal(Convert.ToInt32(tempEQTime(0)), Convert.ToInt32(tempEQTime(1)), localTimeZone)
            Dim EQName = CurrentEQOriginal.Substring(CurrentEQOriginal.IndexOf("】"c) + 1)

            ShowEQ("Ship 2", tempEQTime(0) & ":" & tempEQTime(1), localEQDateIn.ToString("t") & ")", EQName)
        Catch ex As Exception
            RegKey.SetValue(RegKey.LastEQ, "Broken")
            NotifyIcon1.ShowBalloonTip(5000, "", "Looks like something is wrong with EQ announcements. It'll be fixed soon!", ToolTipIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub tsmShowRecentEQ_Click(sender As Object, e As EventArgs) Handles tsmShowRecentEQ.Click
        ThreadPool.QueueUserWorkItem(AddressOf ShowRecentEQs, Nothing)
    End Sub

    Private Sub tscShip_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tscShip.SelectedIndexChanged
        If NotifyIcon1.Visible = True Then
            RegKey.SetValue(RegKey.ShipToQuery, tscShip.Text)
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

        While True
            OpenFileDialog1.Title = "Please select a WAV file"
            OpenFileDialog1.FileName = ""
            OpenFileDialog1.Filter = "WAV files|*.wav"
            Dim result = OpenFileDialog1.ShowDialog()

            If result = DialogResult.Cancel Then
                Exit Sub
            End If

            If Path.GetExtension(OpenFileDialog1.FileName) = ".wav" Then
                Exit While
            Else
                MsgBox("Please select a valid wav file!")
            End If
        End While

        RegKey.SetValue(RegKey.WAVFile, OpenFileDialog1.FileName)
        RegKey.SetValue(RegKey.PlaySound, "Yes")
        tsmSound.Checked = True
    End Sub

    Private Sub tsmStartWithWindows_Click(sender As Object, e As EventArgs) Handles tsmStartWithWindows.Click
        If tsmStartWithWindows.Checked = True Then
            My.Computer.Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True).DeleteValue(Application.ProductName)
            tsmStartWithWindows.Checked = False
            RegKey.SetValue(RegKey.StartWithWindows, "No")
            Exit Sub
        End If
        My.Computer.Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True).SetValue(Application.ProductName, Application.ExecutablePath)
        RegKey.SetValue(RegKey.StartWithWindows, "Yes")
        tsmStartWithWindows.Checked = True
    End Sub

    Private Sub tmrCheckforUpdates_Tick(sender As Object, e As EventArgs) Handles tmrCheckforUpdates.Tick
        Try
            Dim localVersion As String = My.Application.Info.Version.ToString
            Dim wc As New Net.WebClient
            wc.Proxy = Nothing
            Dim source = wc.DownloadString(_freedomUrl & "PSO2Aversion.xml")

            If source.Contains("<VersionHistory>") = True Then

                Dim xm As New Xml.XmlDocument
                xm.LoadXml(source)

                Dim currentVersion As String = xm.SelectSingleNode("//CurrentVersion").ChildNodes(0).InnerText.Trim

                ' TODO: this one is never used?
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
                    If Not String.IsNullOrEmpty(changelog2) Then changelogtotal += vbCrLf & changelog2
                    If Not String.IsNullOrEmpty(changelog3) Then changelogtotal += vbCrLf & changelog3
                    If Not String.IsNullOrEmpty(changelog4) Then changelogtotal += vbCrLf & changelog4
                    If Not String.IsNullOrEmpty(changelog5) Then changelogtotal += vbCrLf & changelog5
                    If Not String.IsNullOrEmpty(changelog6) Then changelogtotal += vbCrLf & changelog6
                    If Not String.IsNullOrEmpty(changelog7) Then changelogtotal += vbCrLf & changelog7
                    If Not String.IsNullOrEmpty(changelog8) Then changelogtotal += vbCrLf & changelog8
                    If Not String.IsNullOrEmpty(changelog9) Then changelogtotal += vbCrLf & changelog9
                    If Not String.IsNullOrEmpty(changelog10) Then changelogtotal += vbCrLf & changelog10
                    Dim updateyesno As MsgBoxResult = MsgBox("You are using an outdated version of PSO2 Alert. You have version " & My.Application.Info.Version.ToString & " and the latest version is " & currentVersion & ". Would you like to download the latest version?" & vbCrLf & vbCrLf & "Here's the list of changes:" & vbCrLf & changelogtotal, MsgBoxStyle.YesNo)
                    If updateyesno = MsgBoxResult.Yes Then
                        wc.DownloadFile(_freedomUrl & "PSO2A%20Updater.exe", "PSO2 Alert Updater.exe")
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
        RegKey.SetValue(RegKey.UrbanEQ, UrbanEQ.Checked)
    End Sub

    Private Sub TertiaryMiningBase_Click(sender As Object, e As EventArgs) Handles TertiaryMiningBase.Click
        RegKey.SetValue(RegKey.TertiaryMiningBase, TertiaryMiningBase.Checked)
    End Sub

    Private Sub ShopAreaConcert_Click(sender As Object, e As EventArgs) Handles ShopAreaConcert.Click
        RegKey.SetValue(RegKey.ShopAreaConcert, ShopAreaConcert.Checked)
    End Sub

    Private Sub SecondaryMiningBase_Click(sender As Object, e As EventArgs) Handles SecondaryMiningBase.Click
        RegKey.SetValue(RegKey.SecondaryMiningBase, SecondaryMiningBase.Checked)
    End Sub

    Private Sub PrimaryMiningBase_Click(sender As Object, e As EventArgs) Handles PrimaryMiningBase.Click
        RegKey.SetValue(RegKey.PrimaryMiningBase, PrimaryMiningBase.Checked)
    End Sub

    Private Sub PlanetNaberiusEQ_Click(sender As Object, e As EventArgs) Handles PlanetNaberiusEQ.Click
        RegKey.SetValue(RegKey.PlanetNaberiusEQ, PlanetNaberiusEQ.Checked)
    End Sub

    Private Sub PlanetLillipaEQ_Click(sender As Object, e As EventArgs) Handles PlanetLillipaEQ.Click
        RegKey.SetValue(RegKey.PlanetLillipaEQ, PlanetLillipaEQ.Checked)
    End Sub

    Private Sub PlanetAmdusciaEQ_Click(sender As Object, e As EventArgs) Handles PlanetAmdusciaEQ.Click
        RegKey.SetValue(RegKey.PlanetAmdusciaEQ, PlanetAmdusciaEQ.Checked)
    End Sub

    Private Sub MechaAwakening_Click(sender As Object, e As EventArgs) Handles MechaAwakening.Click
        RegKey.SetValue(RegKey.MechaAwakening, MechaAwakening.Checked)
    End Sub

    Private Sub InterruptRankings_Click(sender As Object, e As EventArgs) Handles InterruptRankings.Click
        RegKey.SetValue(RegKey.InterruptRankings, InterruptRankings.Checked)
    End Sub

    Private Sub DarkerDen_Click(sender As Object, e As EventArgs) Handles DarkerDen.Click
        RegKey.SetValue(RegKey.DarkerDen, DarkerDen.Checked)
    End Sub

    Private Sub DarkFalzLoser_Click(sender As Object, e As EventArgs) Handles DarkFalzLoser.Click
        RegKey.SetValue(RegKey.DarkFalzLoser, DarkFalzLoser.Checked)
    End Sub

    Private Sub DarkFalzElder_Click(sender As Object, e As EventArgs) Handles DarkFalzElder.Click
        RegKey.SetValue(RegKey.DarkFalzElder, DarkFalzElder.Checked)
    End Sub

    Private Sub BeckoningDarkness_Click(sender As Object, e As EventArgs) Handles BeckoningDarkness.Click
        RegKey.SetValue(RegKey.BeckoningDarkness, BeckoningDarkness.Checked)
    End Sub

    Private Sub BeachWars2_Click(sender As Object, e As EventArgs) Handles BeachWars2.Click
        RegKey.SetValue(RegKey.BeachWars2, BeachWars2.Checked)
    End Sub

    Private Sub ThePitchBlackProvince_Click(sender As Object, e As EventArgs) Handles ThePitchBlackProvince.Click
        RegKey.SetValue(RegKey.ThePitchBlackProvince, ThePitchBlackProvince.Checked)
    End Sub

    Private Sub AttackOnMagatsu_Click(sender As Object, e As EventArgs) Handles AttackOnMagatsu.Click
        RegKey.SetValue(RegKey.AttackonMagatsu, AttackOnMagatsu.Checked)
    End Sub
End Class
