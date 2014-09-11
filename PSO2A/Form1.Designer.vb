<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.tmrCheck = New System.Windows.Forms.Timer(Me.components)
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.traymenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmVersion = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmSelectEQs = New System.Windows.Forms.ToolStripMenuItem()
        Me.BeachWars2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.BeckoningDarkness = New System.Windows.Forms.ToolStripMenuItem()
        Me.DarkFalzElder = New System.Windows.Forms.ToolStripMenuItem()
        Me.DarkFalzLoser = New System.Windows.Forms.ToolStripMenuItem()
        Me.DarkerDen = New System.Windows.Forms.ToolStripMenuItem()
        Me.InterruptRankings = New System.Windows.Forms.ToolStripMenuItem()
        Me.MechaAwakening = New System.Windows.Forms.ToolStripMenuItem()
        Me.PlanetAmdusciaEQ = New System.Windows.Forms.ToolStripMenuItem()
        Me.PlanetLillipaEQ = New System.Windows.Forms.ToolStripMenuItem()
        Me.PlanetNaberiusEQ = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrimaryMiningBase = New System.Windows.Forms.ToolStripMenuItem()
        Me.SecondaryMiningBase = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShopAreaConcert = New System.Windows.Forms.ToolStripMenuItem()
        Me.TertiaryMiningBase = New System.Windows.Forms.ToolStripMenuItem()
        Me.UrbanEQ = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmSelectMonitor = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrimaryMonitorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SecondaryMonitorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmStartWithWindows = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmLogin = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmReportEQ = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmReportCaves = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmReportFloatingContinent = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmReportFireSwirl = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmReportDarkFalz = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmReportSuperFalz = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmReportDesert = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmReportTunnels = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmReportForest = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmReportWithWindAndRain = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmReportCity = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmReportCoast = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmTesting = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmReportGeneral = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmSound = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmShowRecentEQ = New System.Windows.Forms.ToolStripMenuItem()
        Me.tscShip = New System.Windows.Forms.ToolStripComboBox()
        Me.tsmExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmDebugShowEQ = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmASFS = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmCaves = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmCity = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmCoast = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmDarkFalz = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmDesert = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmSuperFalz = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmFloating = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmForest = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmGeneral = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmTunnels = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmWindAndRain = New System.Windows.Forms.ToolStripMenuItem()
        Me.picEQImage = New System.Windows.Forms.PictureBox()
        Me.lblEQText = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.tmrDisplay = New System.Windows.Forms.Timer(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.tmrCheckforUpdates = New System.Windows.Forms.Timer(Me.components)
        Me.ThePitchBlackProvince = New System.Windows.Forms.ToolStripMenuItem()
        Me.traymenu.SuspendLayout()
        CType(Me.picEQImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(363, 229)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(30, 20)
        Me.TextBox1.TabIndex = 0
        '
        'tmrCheck
        '
        Me.tmrCheck.Enabled = True
        Me.tmrCheck.Interval = 60000
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.BalloonTipText = "PSO2 Alert"
        Me.NotifyIcon1.ContextMenuStrip = Me.traymenu
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "PSO2 Alert"
        Me.NotifyIcon1.Visible = True
        '
        'traymenu
        '
        Me.traymenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmVersion, Me.tsmSelectEQs, Me.tsmSelectMonitor, Me.tsmStartWithWindows, Me.tsmLogin, Me.tsmReportEQ, Me.ToolStripMenuItem1, Me.tsmSound, Me.tsmShowRecentEQ, Me.tscShip, Me.tsmExit, Me.tsmDebugShowEQ})
        Me.traymenu.Name = "traymenu"
        Me.traymenu.Size = New System.Drawing.Size(191, 295)
        '
        'tsmVersion
        '
        Me.tsmVersion.Enabled = False
        Me.tsmVersion.Name = "tsmVersion"
        Me.tsmVersion.Size = New System.Drawing.Size(190, 22)
        '
        'tsmSelectEQs
        '
        Me.tsmSelectEQs.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BeachWars2, Me.BeckoningDarkness, Me.DarkFalzElder, Me.DarkFalzLoser, Me.DarkerDen, Me.InterruptRankings, Me.MechaAwakening, Me.PlanetAmdusciaEQ, Me.PlanetLillipaEQ, Me.PlanetNaberiusEQ, Me.PrimaryMiningBase, Me.SecondaryMiningBase, Me.ShopAreaConcert, Me.TertiaryMiningBase, Me.ThePitchBlackProvince, Me.UrbanEQ})
        Me.tsmSelectEQs.Name = "tsmSelectEQs"
        Me.tsmSelectEQs.Size = New System.Drawing.Size(190, 22)
        Me.tsmSelectEQs.Text = "Show these EQs"
        '
        'BeachWars2
        '
        Me.BeachWars2.Checked = True
        Me.BeachWars2.CheckOnClick = True
        Me.BeachWars2.CheckState = System.Windows.Forms.CheckState.Checked
        Me.BeachWars2.Name = "BeachWars2"
        Me.BeachWars2.Size = New System.Drawing.Size(204, 22)
        Me.BeachWars2.Text = "Beach Wars 2"
        '
        'BeckoningDarkness
        '
        Me.BeckoningDarkness.Checked = True
        Me.BeckoningDarkness.CheckOnClick = True
        Me.BeckoningDarkness.CheckState = System.Windows.Forms.CheckState.Checked
        Me.BeckoningDarkness.Name = "BeckoningDarkness"
        Me.BeckoningDarkness.Size = New System.Drawing.Size(204, 22)
        Me.BeckoningDarkness.Text = "Beckoning Darkness"
        '
        'DarkFalzElder
        '
        Me.DarkFalzElder.Checked = True
        Me.DarkFalzElder.CheckOnClick = True
        Me.DarkFalzElder.CheckState = System.Windows.Forms.CheckState.Checked
        Me.DarkFalzElder.Name = "DarkFalzElder"
        Me.DarkFalzElder.Size = New System.Drawing.Size(204, 22)
        Me.DarkFalzElder.Text = "Dark Falz Elder"
        '
        'DarkFalzLoser
        '
        Me.DarkFalzLoser.Checked = True
        Me.DarkFalzLoser.CheckOnClick = True
        Me.DarkFalzLoser.CheckState = System.Windows.Forms.CheckState.Checked
        Me.DarkFalzLoser.Name = "DarkFalzLoser"
        Me.DarkFalzLoser.Size = New System.Drawing.Size(204, 22)
        Me.DarkFalzLoser.Text = "Dark Falz Loser"
        '
        'DarkerDen
        '
        Me.DarkerDen.Checked = True
        Me.DarkerDen.CheckOnClick = True
        Me.DarkerDen.CheckState = System.Windows.Forms.CheckState.Checked
        Me.DarkerDen.Name = "DarkerDen"
        Me.DarkerDen.Size = New System.Drawing.Size(204, 22)
        Me.DarkerDen.Text = "Darker Den"
        '
        'InterruptRankings
        '
        Me.InterruptRankings.Checked = True
        Me.InterruptRankings.CheckOnClick = True
        Me.InterruptRankings.CheckState = System.Windows.Forms.CheckState.Checked
        Me.InterruptRankings.Name = "InterruptRankings"
        Me.InterruptRankings.Size = New System.Drawing.Size(204, 22)
        Me.InterruptRankings.Text = "Interrupt Rankings"
        '
        'MechaAwakening
        '
        Me.MechaAwakening.Checked = True
        Me.MechaAwakening.CheckOnClick = True
        Me.MechaAwakening.CheckState = System.Windows.Forms.CheckState.Checked
        Me.MechaAwakening.Name = "MechaAwakening"
        Me.MechaAwakening.Size = New System.Drawing.Size(204, 22)
        Me.MechaAwakening.Text = "Mecha Awakening"
        '
        'PlanetAmdusciaEQ
        '
        Me.PlanetAmdusciaEQ.Checked = True
        Me.PlanetAmdusciaEQ.CheckOnClick = True
        Me.PlanetAmdusciaEQ.CheckState = System.Windows.Forms.CheckState.Checked
        Me.PlanetAmdusciaEQ.Name = "PlanetAmdusciaEQ"
        Me.PlanetAmdusciaEQ.Size = New System.Drawing.Size(204, 22)
        Me.PlanetAmdusciaEQ.Text = "Planet Amduscia EQ"
        '
        'PlanetLillipaEQ
        '
        Me.PlanetLillipaEQ.Checked = True
        Me.PlanetLillipaEQ.CheckOnClick = True
        Me.PlanetLillipaEQ.CheckState = System.Windows.Forms.CheckState.Checked
        Me.PlanetLillipaEQ.Name = "PlanetLillipaEQ"
        Me.PlanetLillipaEQ.Size = New System.Drawing.Size(204, 22)
        Me.PlanetLillipaEQ.Text = "Planet Lillipa EQ"
        '
        'PlanetNaberiusEQ
        '
        Me.PlanetNaberiusEQ.Checked = True
        Me.PlanetNaberiusEQ.CheckOnClick = True
        Me.PlanetNaberiusEQ.CheckState = System.Windows.Forms.CheckState.Checked
        Me.PlanetNaberiusEQ.Name = "PlanetNaberiusEQ"
        Me.PlanetNaberiusEQ.Size = New System.Drawing.Size(204, 22)
        Me.PlanetNaberiusEQ.Text = "Planet Naberius EQ"
        '
        'PrimaryMiningBase
        '
        Me.PrimaryMiningBase.Checked = True
        Me.PrimaryMiningBase.CheckOnClick = True
        Me.PrimaryMiningBase.CheckState = System.Windows.Forms.CheckState.Checked
        Me.PrimaryMiningBase.Name = "PrimaryMiningBase"
        Me.PrimaryMiningBase.Size = New System.Drawing.Size(204, 22)
        Me.PrimaryMiningBase.Text = "Primary Mining Base"
        '
        'SecondaryMiningBase
        '
        Me.SecondaryMiningBase.Checked = True
        Me.SecondaryMiningBase.CheckOnClick = True
        Me.SecondaryMiningBase.CheckState = System.Windows.Forms.CheckState.Checked
        Me.SecondaryMiningBase.Name = "SecondaryMiningBase"
        Me.SecondaryMiningBase.Size = New System.Drawing.Size(204, 22)
        Me.SecondaryMiningBase.Text = "Secondary Mining Base"
        '
        'ShopAreaConcert
        '
        Me.ShopAreaConcert.Checked = True
        Me.ShopAreaConcert.CheckOnClick = True
        Me.ShopAreaConcert.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ShopAreaConcert.Name = "ShopAreaConcert"
        Me.ShopAreaConcert.Size = New System.Drawing.Size(204, 22)
        Me.ShopAreaConcert.Text = "Shop Area Concert"
        '
        'TertiaryMiningBase
        '
        Me.TertiaryMiningBase.Checked = True
        Me.TertiaryMiningBase.CheckOnClick = True
        Me.TertiaryMiningBase.CheckState = System.Windows.Forms.CheckState.Checked
        Me.TertiaryMiningBase.Name = "TertiaryMiningBase"
        Me.TertiaryMiningBase.Size = New System.Drawing.Size(204, 22)
        Me.TertiaryMiningBase.Text = "Tertiary Mining Base"
        '
        'UrbanEQ
        '
        Me.UrbanEQ.Checked = True
        Me.UrbanEQ.CheckOnClick = True
        Me.UrbanEQ.CheckState = System.Windows.Forms.CheckState.Checked
        Me.UrbanEQ.Name = "UrbanEQ"
        Me.UrbanEQ.Size = New System.Drawing.Size(204, 22)
        Me.UrbanEQ.Text = "Urban EQ"
        '
        'tsmSelectMonitor
        '
        Me.tsmSelectMonitor.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrimaryMonitorToolStripMenuItem, Me.SecondaryMonitorToolStripMenuItem})
        Me.tsmSelectMonitor.Name = "tsmSelectMonitor"
        Me.tsmSelectMonitor.Size = New System.Drawing.Size(190, 22)
        Me.tsmSelectMonitor.Text = "Display EQ on..."
        Me.tsmSelectMonitor.Visible = False
        '
        'PrimaryMonitorToolStripMenuItem
        '
        Me.PrimaryMonitorToolStripMenuItem.Name = "PrimaryMonitorToolStripMenuItem"
        Me.PrimaryMonitorToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.PrimaryMonitorToolStripMenuItem.Text = "Primary Monitor"
        '
        'SecondaryMonitorToolStripMenuItem
        '
        Me.SecondaryMonitorToolStripMenuItem.Name = "SecondaryMonitorToolStripMenuItem"
        Me.SecondaryMonitorToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.SecondaryMonitorToolStripMenuItem.Text = "Secondary Monitor"
        '
        'tsmStartWithWindows
        '
        Me.tsmStartWithWindows.Name = "tsmStartWithWindows"
        Me.tsmStartWithWindows.Size = New System.Drawing.Size(190, 22)
        Me.tsmStartWithWindows.Text = "Start with Windows"
        '
        'tsmLogin
        '
        Me.tsmLogin.Enabled = False
        Me.tsmLogin.Name = "tsmLogin"
        Me.tsmLogin.Size = New System.Drawing.Size(190, 22)
        Me.tsmLogin.Text = "Log in to report an EQ"
        Me.tsmLogin.Visible = False
        '
        'tsmReportEQ
        '
        Me.tsmReportEQ.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmReportCaves, Me.tsmReportFloatingContinent, Me.tsmReportFireSwirl, Me.tsmReportDarkFalz, Me.tsmReportSuperFalz, Me.tsmReportDesert, Me.tsmReportTunnels, Me.tsmReportForest, Me.tsmReportWithWindAndRain, Me.tsmReportCity, Me.tsmReportCoast, Me.tsmTesting, Me.tsmReportGeneral})
        Me.tsmReportEQ.Enabled = False
        Me.tsmReportEQ.Name = "tsmReportEQ"
        Me.tsmReportEQ.Size = New System.Drawing.Size(190, 22)
        Me.tsmReportEQ.Text = "Report EQ"
        Me.tsmReportEQ.Visible = False
        '
        'tsmReportCaves
        '
        Me.tsmReportCaves.Name = "tsmReportCaves"
        Me.tsmReportCaves.Size = New System.Drawing.Size(241, 22)
        Me.tsmReportCaves.Text = "Amduscia (Caves)"
        '
        'tsmReportFloatingContinent
        '
        Me.tsmReportFloatingContinent.Name = "tsmReportFloatingContinent"
        Me.tsmReportFloatingContinent.Size = New System.Drawing.Size(241, 22)
        Me.tsmReportFloatingContinent.Text = "Amduscia (Floating Continent)"
        '
        'tsmReportFireSwirl
        '
        Me.tsmReportFireSwirl.Name = "tsmReportFireSwirl"
        Me.tsmReportFireSwirl.Size = New System.Drawing.Size(241, 22)
        Me.tsmReportFireSwirl.Text = "Arks Ship (Fire Swirl)"
        '
        'tsmReportDarkFalz
        '
        Me.tsmReportDarkFalz.Name = "tsmReportDarkFalz"
        Me.tsmReportDarkFalz.Size = New System.Drawing.Size(241, 22)
        Me.tsmReportDarkFalz.Text = "Dark Falz"
        '
        'tsmReportSuperFalz
        '
        Me.tsmReportSuperFalz.Name = "tsmReportSuperFalz"
        Me.tsmReportSuperFalz.Size = New System.Drawing.Size(241, 22)
        Me.tsmReportSuperFalz.Text = "Falz Elder Fragment (Super Falz)"
        '
        'tsmReportDesert
        '
        Me.tsmReportDesert.Name = "tsmReportDesert"
        Me.tsmReportDesert.Size = New System.Drawing.Size(241, 22)
        Me.tsmReportDesert.Text = "Lillipa (Desert)"
        '
        'tsmReportTunnels
        '
        Me.tsmReportTunnels.Name = "tsmReportTunnels"
        Me.tsmReportTunnels.Size = New System.Drawing.Size(241, 22)
        Me.tsmReportTunnels.Text = "Lillipa (Tunnels)"
        '
        'tsmReportForest
        '
        Me.tsmReportForest.Name = "tsmReportForest"
        Me.tsmReportForest.Size = New System.Drawing.Size(241, 22)
        Me.tsmReportForest.Text = "Naberius (Forest)"
        '
        'tsmReportWithWindAndRain
        '
        Me.tsmReportWithWindAndRain.Name = "tsmReportWithWindAndRain"
        Me.tsmReportWithWindAndRain.Size = New System.Drawing.Size(241, 22)
        Me.tsmReportWithWindAndRain.Text = "Naberius (Wind And Rain)"
        '
        'tsmReportCity
        '
        Me.tsmReportCity.Name = "tsmReportCity"
        Me.tsmReportCity.Size = New System.Drawing.Size(241, 22)
        Me.tsmReportCity.Text = "Urban (City)"
        '
        'tsmReportCoast
        '
        Me.tsmReportCoast.Name = "tsmReportCoast"
        Me.tsmReportCoast.Size = New System.Drawing.Size(241, 22)
        Me.tsmReportCoast.Text = "Vorpa (Coast)"
        '
        'tsmTesting
        '
        Me.tsmTesting.Name = "tsmTesting"
        Me.tsmTesting.Size = New System.Drawing.Size(241, 22)
        Me.tsmTesting.Text = "Testing"
        '
        'tsmReportGeneral
        '
        Me.tsmReportGeneral.Name = "tsmReportGeneral"
        Me.tsmReportGeneral.Size = New System.Drawing.Size(241, 22)
        Me.tsmReportGeneral.Text = "Unknown/Other"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Enabled = False
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(190, 22)
        Me.ToolStripMenuItem1.Text = "Report EQ (System 2)"
        Me.ToolStripMenuItem1.Visible = False
        '
        'tsmSound
        '
        Me.tsmSound.Name = "tsmSound"
        Me.tsmSound.Size = New System.Drawing.Size(190, 22)
        Me.tsmSound.Text = "Play a sound..."
        '
        'tsmShowRecentEQ
        '
        Me.tsmShowRecentEQ.Name = "tsmShowRecentEQ"
        Me.tsmShowRecentEQ.Size = New System.Drawing.Size(190, 22)
        Me.tsmShowRecentEQ.Text = "Show Last EQ"
        '
        'tscShip
        '
        Me.tscShip.Enabled = False
        Me.tscShip.Items.AddRange(New Object() {"Ship01", "Ship02", "Ship03", "Ship04", "Ship05", "Ship06", "Ship07", "Ship08", "Ship09", "Ship10"})
        Me.tscShip.Name = "tscShip"
        Me.tscShip.Size = New System.Drawing.Size(121, 23)
        '
        'tsmExit
        '
        Me.tsmExit.Name = "tsmExit"
        Me.tsmExit.Size = New System.Drawing.Size(190, 22)
        Me.tsmExit.Text = "Exit"
        '
        'tsmDebugShowEQ
        '
        Me.tsmDebugShowEQ.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmASFS, Me.tsmCaves, Me.tsmCity, Me.tsmCoast, Me.tsmDarkFalz, Me.tsmDesert, Me.tsmSuperFalz, Me.tsmFloating, Me.tsmForest, Me.tsmGeneral, Me.tsmTunnels, Me.tsmWindAndRain})
        Me.tsmDebugShowEQ.Name = "tsmDebugShowEQ"
        Me.tsmDebugShowEQ.Size = New System.Drawing.Size(190, 22)
        Me.tsmDebugShowEQ.Text = "DEBUG: Force EQ"
        Me.tsmDebugShowEQ.Visible = False
        '
        'tsmASFS
        '
        Me.tsmASFS.Name = "tsmASFS"
        Me.tsmASFS.Size = New System.Drawing.Size(181, 22)
        Me.tsmASFS.Text = "Arks Ship Fire Swirl"
        '
        'tsmCaves
        '
        Me.tsmCaves.Name = "tsmCaves"
        Me.tsmCaves.Size = New System.Drawing.Size(181, 22)
        Me.tsmCaves.Text = "Caves"
        '
        'tsmCity
        '
        Me.tsmCity.Name = "tsmCity"
        Me.tsmCity.Size = New System.Drawing.Size(181, 22)
        Me.tsmCity.Text = "City"
        '
        'tsmCoast
        '
        Me.tsmCoast.Name = "tsmCoast"
        Me.tsmCoast.Size = New System.Drawing.Size(181, 22)
        Me.tsmCoast.Text = "Coast"
        '
        'tsmDarkFalz
        '
        Me.tsmDarkFalz.Name = "tsmDarkFalz"
        Me.tsmDarkFalz.Size = New System.Drawing.Size(181, 22)
        Me.tsmDarkFalz.Text = "Dark Falz"
        '
        'tsmDesert
        '
        Me.tsmDesert.Name = "tsmDesert"
        Me.tsmDesert.Size = New System.Drawing.Size(181, 22)
        Me.tsmDesert.Text = "Desert"
        '
        'tsmSuperFalz
        '
        Me.tsmSuperFalz.Name = "tsmSuperFalz"
        Me.tsmSuperFalz.Size = New System.Drawing.Size(181, 22)
        Me.tsmSuperFalz.Text = "Falz Elder Fragment"
        '
        'tsmFloating
        '
        Me.tsmFloating.Name = "tsmFloating"
        Me.tsmFloating.Size = New System.Drawing.Size(181, 22)
        Me.tsmFloating.Text = "Floating Continent"
        '
        'tsmForest
        '
        Me.tsmForest.Name = "tsmForest"
        Me.tsmForest.Size = New System.Drawing.Size(181, 22)
        Me.tsmForest.Text = "Forest"
        '
        'tsmGeneral
        '
        Me.tsmGeneral.Name = "tsmGeneral"
        Me.tsmGeneral.Size = New System.Drawing.Size(181, 22)
        Me.tsmGeneral.Text = "General"
        '
        'tsmTunnels
        '
        Me.tsmTunnels.Name = "tsmTunnels"
        Me.tsmTunnels.Size = New System.Drawing.Size(181, 22)
        Me.tsmTunnels.Text = "Tunnels"
        '
        'tsmWindAndRain
        '
        Me.tsmWindAndRain.Name = "tsmWindAndRain"
        Me.tsmWindAndRain.Size = New System.Drawing.Size(181, 22)
        Me.tsmWindAndRain.Text = "With Wind And Rain"
        '
        'picEQImage
        '
        Me.picEQImage.Location = New System.Drawing.Point(23, 42)
        Me.picEQImage.Name = "picEQImage"
        Me.picEQImage.Size = New System.Drawing.Size(55, 55)
        Me.picEQImage.TabIndex = 1
        Me.picEQImage.TabStop = False
        '
        'lblEQText
        '
        Me.lblEQText.AutoSize = True
        Me.lblEQText.BackColor = System.Drawing.Color.Transparent
        Me.lblEQText.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEQText.ForeColor = System.Drawing.Color.White
        Me.lblEQText.Location = New System.Drawing.Point(85, 34)
        Me.lblEQText.MaximumSize = New System.Drawing.Size(253, 68)
        Me.lblEQText.Name = "lblEQText"
        Me.lblEQText.Size = New System.Drawing.Size(100, 17)
        Me.lblEQText.TabIndex = 2
        Me.lblEQText.Text = "EQDescription"
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblTitle.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblTitle.Location = New System.Drawing.Point(8, 6)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(221, 15)
        Me.lblTitle.TabIndex = 3
        Me.lblTitle.Text = "ShipXX EQ Alert (DateStart-DateFinish)"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tmrDisplay
        '
        Me.tmrDisplay.Interval = 10000
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'tmrCheckforUpdates
        '
        Me.tmrCheckforUpdates.Enabled = True
        Me.tmrCheckforUpdates.Interval = 3600000
        '
        'ThePitchBlackProvince
        '
        Me.ThePitchBlackProvince.Checked = True
        Me.ThePitchBlackProvince.CheckOnClick = True
        Me.ThePitchBlackProvince.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ThePitchBlackProvince.Name = "ThePitchBlackProvince"
        Me.ThePitchBlackProvince.Size = New System.Drawing.Size(204, 22)
        Me.ThePitchBlackProvince.Text = "The Pitch Black Province"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.BackgroundImage = Global.PSO2A.My.Resources.Resources.pop_up
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(339, 119)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.lblEQText)
        Me.Controls.Add(Me.picEQImage)
        Me.Controls.Add(Me.TextBox1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.Opacity = 0.0R
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.TopMost = True
        Me.TransparencyKey = System.Drawing.SystemColors.ActiveCaption
        Me.traymenu.ResumeLayout(False)
        CType(Me.picEQImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents tmrCheck As System.Windows.Forms.Timer
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents traymenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tsmShowRecentEQ As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents picEQImage As System.Windows.Forms.PictureBox
    Friend WithEvents lblEQText As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents tsmDebugShowEQ As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmDarkFalz As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tmrDisplay As System.Windows.Forms.Timer
    Friend WithEvents tsmASFS As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmCaves As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmCity As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmCoast As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmDesert As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmSuperFalz As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmFloating As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmForest As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmGeneral As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmTunnels As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmWindAndRain As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tscShip As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents tsmSound As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents tsmStartWithWindows As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tmrCheckforUpdates As System.Windows.Forms.Timer
    Friend WithEvents tsmLogin As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmReportEQ As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmReportFireSwirl As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmReportCaves As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmReportCity As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmReportCoast As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmReportDarkFalz As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmReportDesert As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmReportSuperFalz As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmReportFloatingContinent As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmReportForest As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmReportGeneral As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmReportTunnels As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmReportWithWindAndRain As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmTesting As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmVersion As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmSelectMonitor As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrimaryMonitorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SecondaryMonitorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmSelectEQs As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BeachWars2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BeckoningDarkness As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DarkFalzElder As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DarkFalzLoser As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DarkerDen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InterruptRankings As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MechaAwakening As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PlanetAmdusciaEQ As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PlanetLillipaEQ As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PlanetNaberiusEQ As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrimaryMiningBase As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SecondaryMiningBase As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShopAreaConcert As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TertiaryMiningBase As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UrbanEQ As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ThePitchBlackProvince As System.Windows.Forms.ToolStripMenuItem

End Class
