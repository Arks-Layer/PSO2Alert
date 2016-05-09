Imports Microsoft.Win32

Public Class RegKey
    Public Const BeachWars2 = "Beach Wars 2"
    Public Const BeckoningDarkness = "Beckoning Darkness"
    Public Const DarkFalzElder = "Dark Falz Elder"
    Public Const DarkFalzBoth = "A Profound Invasion"
    Public Const DarkFalzLoser = "Dark Falz Loser"
    Public Const DarkerDen = "Darker Den"
    Public Const InterruptRankings = "Interrupt Rankings"
    Public Const LastEQ = "LastEQ"
    Public Const MechaAwakening = "Mecha Awakening"
    Public Const PlanetAmdusciaEQ = "Planet Amduscia EQ"
    Public Const PlanetLillipaEQ = "Planet Lillipa EQ"
    Public Const PlanetNaberiusEQ = "Planet Naberius EQ"
    Public Const PlaySound = "PlaySound"
    Public Const PrimaryMiningBase = "Primary Mining Base"
    Public Const SecondaryMiningBase = "Secondary Mining Base"
    Public Const ShipToQuery = "ShipToQuery"
    Public Const ShopAreaConcert = "Shop Area Live Event"
    Public Const StartWithWindows = "StartWithWindows"
    Public Const TertiaryMiningBase = "Tertiary Mining Base"
    Public Const ThePitchBlackProvince = "The Pitch Black Province"
    Public Const AttackonMagatsu = "Attack on Magatsu"
    Public Const ProfoundDarkness = "Profound Darkness"
    Public Const MiningBaseDemise = "Mining Base Demise"
    Public Const NaberiusForest = "Naberius: Forest EQ"
    Public Const NaberiusTundra = "Naberius: Tundra EQ"
    Public Const NaberiusRuins = "Naberius: Ruins EQ"
    Public Const VolcanicCaves = "Volcanic Caves"
    Public Const LillipaDesert = "Lillipa: Desert EQ"
    Public Const LillipaQuarry = "Lillipa: Quarry EQ"
    Public Const AmdusciaSkyscape = "Amduscia: Skyscape EQ"
    Public Const AmdusciaSanctum = "Amduscia: Sanctum EQ"
    Public Const PlanetVopar = "Planet Vopar EQ"
    Public Const VoparCoast = "Vopar: Coast EQ"
    Public Const VoparSeabed = "Vopar: Seabed EQ"
    Public Const VoparFloatingFacility = "Vopar: Floating Facility EQ"
    Public Const ARKSShipUrban = "ARKS Ship Urban EQ"
    Public Const LillipaSubterraneanTunnels = "Lillipa: Subterranean Tunnels EQ"
    Public Const HarkotanShironia = "Harkotan: Shironia EQ"
    Public Const PlanetHarkotan = "Planet Harkotan EQ"
    Public Const HarkotanKuron = "Harkotan: Kuron EQ"

    Public Const UrbanEQ = "Urban EQ"
    Public Const WAVFile = "WAVFile"

    Private Shared RegistryCache As Dictionary(Of String, Object) = New Dictionary(Of String, Object)
    Private Shared RegistrySubKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\AIDA", True)

    Public Shared Function GetValue(Of T)(Key As String) As T
        Try
            Dim returnValue As Object = Nothing
            If RegistryCache.TryGetValue(Key, returnValue) Then Return DirectCast(returnValue, T)

            returnValue = RegistrySubKey.GetValue(Key, Nothing)
            If returnValue IsNot Nothing Then RegistryCache.Add(Key, returnValue)

            Return DirectCast(returnValue, T)
        Catch
            Return Nothing
        End Try
    End Function

    Public Shared Sub SetValue(Of T)(Key As String, Value As T)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\AIDA", Key, Value)
        RegistryCache(Key) = Value
    End Sub
End Class