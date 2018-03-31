using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace RocketLeagueReplaysToDataSet.Data.RawReplayJsonClasses
{
    public partial class ReplayJson
    {
        [JsonProperty("Part1Length")]
        public long Part1Length { get; set; }

        [JsonProperty("Part1Crc")]
        public string Part1Crc { get; set; }

        [JsonProperty("EngineVersion")]
        public long EngineVersion { get; set; }

        [JsonProperty("LicenseeVersion")]
        public long LicenseeVersion { get; set; }

        [JsonProperty("ReplayClass")]
        public string ReplayClass { get; set; }

        [JsonProperty("Properties")]
        public Properties Properties { get; set; }

        [JsonProperty("Part2Crc")]
        public string Part2Crc { get; set; }

        [JsonProperty("Levels")]
        public Level[] Levels { get; set; }

        [JsonProperty("Frames")]
        public Frame[] Frames { get; set; }

        [JsonProperty("TickMarks")]
        public TickMark[] TickMarks { get; set; }

        [JsonProperty("Packages")]
        public string[] Packages { get; set; }

        [JsonProperty("Objects")]
        public string[] Objects { get; set; }

        [JsonProperty("Names")]
        public string[] Names { get; set; }

        [JsonProperty("ClassIndexes")]
        public ClassIndex[] ClassIndexes { get; set; }

        [JsonProperty("ClassNetCaches")]
        public ClassNetCach[] ClassNetCaches { get; set; }
    }

    public partial class ClassIndex
    {
        [JsonProperty("Class")]
        public string Class { get; set; }

        [JsonProperty("Index")]
        public long Index { get; set; }
    }

    public partial class ClassNetCach
    {
        [JsonProperty("ObjectIndex")]
        public long ObjectIndex { get; set; }

        [JsonProperty("ParentId")]
        public long ParentId { get; set; }

        [JsonProperty("Id")]
        public long Id { get; set; }

        [JsonProperty("Properties")]
        public Property[] Properties { get; set; }

        [JsonProperty("Children")]
        public ClassNetCach[] Children { get; set; }
    }

    public partial class Property
    {
        [JsonProperty("Index")]
        public long Index { get; set; }

        [JsonProperty("Id")]
        public long Id { get; set; }
    }

    public partial class Frame
    {
        [JsonProperty("Time")]
        public double Time { get; set; }

        [JsonProperty("Delta")]
        public double Delta { get; set; }

        [JsonProperty("DeletedActorIds")]
        public long[] DeletedActorIds { get; set; }

        [JsonProperty("ActorUpdates")]
        public ActorUpdate[] ActorUpdates { get; set; }
    }

    public partial class ActorUpdate
    {
        [JsonProperty("Id")]
        public long Id { get; set; }

        [JsonProperty("TypeName")]
        public string TypeName { get; set; }

        [JsonProperty("ClassName")]
        public string ClassName { get; set; }

        [JsonProperty("InitialPosition")]
        public InitialPosition InitialPosition { get; set; }

        [JsonProperty("TAGame.RBActor_TA:ReplicatedRBState")]
        public TaGameRbActorTaReplicatedRbState TaGameRbActorTaReplicatedRbState { get; set; }

        [JsonProperty("TAGame.Ball_TA:GameEvent")]
        public EnginePawnPlayerReplicationInfo TaGameBallTaGameEvent { get; set; }

        [JsonProperty("TAGame.GameEvent_TA:ReplicatedStateName")]
        public long? TaGameGameEventTaReplicatedStateName { get; set; }

        [JsonProperty("TAGame.GameEvent_TA:BotSkill")]
        public long? TaGameGameEventTaBotSkill { get; set; }

        [JsonProperty("TAGame.GameEvent_TA:MatchTypeClass")]
        public EngineGameReplicationInfoGameClass[] TaGameGameEventTaMatchTypeClass { get; set; }

        [JsonProperty("TAGame.GameEvent_Team_TA:MaxTeamSize")]
        public long? TaGameGameEventTeamTaMaxTeamSize { get; set; }

        [JsonProperty("TAGame.GameEvent_Soccar_TA:SecondsRemaining")]
        public long? TaGameGameEventSoccarTaSecondsRemaining { get; set; }

        [JsonProperty("TAGame.Team_TA:GameEvent")]
        public EnginePawnPlayerReplicationInfo TaGameTeamTaGameEvent { get; set; }

        [JsonProperty("Engine.GameReplicationInfo:GameClass")]
        public EngineGameReplicationInfoGameClass[] EngineGameReplicationInfoGameClass { get; set; }

        [JsonProperty("Engine.GameReplicationInfo:ServerName")]
        public string EngineGameReplicationInfoServerName { get; set; }

        [JsonProperty("ProjectX.GRI_X:MatchGUID")]
        public string ProjectXGriXMatchGuid { get; set; }

        [JsonProperty("ProjectX.GRI_X:bGameStarted")]
        public bool? ProjectXGriXBGameStarted { get; set; }

        [JsonProperty("ProjectX.GRI_X:GameServerID")]
        public long[] ProjectXGriXGameServerId { get; set; }

        [JsonProperty("ProjectX.GRI_X:Reservations")]
        public ProjectXGriXReservations ProjectXGriXReservations { get; set; }

        [JsonProperty("ProjectX.GRI_X:ReplicatedGameMutatorIndex")]
        public long? ProjectXGriXReplicatedGameMutatorIndex { get; set; }

        [JsonProperty("ProjectX.GRI_X:ReplicatedGamePlaylist")]
        public long? ProjectXGriXReplicatedGamePlaylist { get; set; }

        [JsonProperty("Engine.PlayerReplicationInfo:Ping")]
        public long? EnginePlayerReplicationInfoPing { get; set; }

        [JsonProperty("Engine.PlayerReplicationInfo:PlayerName")]
        public string EnginePlayerReplicationInfoPlayerName { get; set; }

        [JsonProperty("Engine.PlayerReplicationInfo:Team")]
        public EnginePawnPlayerReplicationInfo EnginePlayerReplicationInfoTeam { get; set; }

        [JsonProperty("Engine.PlayerReplicationInfo:bReadyToPlay")]
        public bool? EnginePlayerReplicationInfoBReadyToPlay { get; set; }

        [JsonProperty("Engine.PlayerReplicationInfo:UniqueId")]
        public EnginePlayerReplicationInfoUniqueId EnginePlayerReplicationInfoUniqueId { get; set; }

        [JsonProperty("Engine.PlayerReplicationInfo:PlayerID")]
        public long? EnginePlayerReplicationInfoPlayerId { get; set; }

        [JsonProperty("TAGame.PRI_TA:TotalXP")]
        public long? TaGamePriTaTotalXp { get; set; }

        [JsonProperty("TAGame.PRI_TA:PartyLeader")]
        public TaGamePriTaPartyLeader TaGamePriTaPartyLeader { get; set; }

        [JsonProperty("TAGame.PRI_TA:PersistentCamera")]
        public EngineGameReplicationInfoGameClass[] TaGamePriTaPersistentCamera { get; set; }

        [JsonProperty("TAGame.PRI_TA:ClientLoadoutsOnline")]
        public TaGamePriTaClientLoadoutsOnline TaGamePriTaClientLoadoutsOnline { get; set; }

        [JsonProperty("TAGame.PRI_TA:ClientLoadouts")]
        public TaGamePriTaClientLoadouts TaGamePriTaClientLoadouts { get; set; }

        [JsonProperty("TAGame.PRI_TA:ReplicatedGameEvent")]
        public EnginePawnPlayerReplicationInfo TaGamePriTaReplicatedGameEvent { get; set; }

        [JsonProperty("TAGame.PRI_TA:PlayerHistoryValid")]
        public bool? TaGamePriTaPlayerHistoryValid { get; set; }

        [JsonProperty("TAGame.PRI_TA:bOnlineLoadoutsSet")]
        public bool? TaGamePriTaBOnlineLoadoutsSet { get; set; }

        [JsonProperty("TAGame.CameraSettingsActor_TA:ProfileSettings")]
        public TaGameCameraSettingsActorTaProfileSettings TaGameCameraSettingsActorTaProfileSettings { get; set; }

        [JsonProperty("TAGame.CameraSettingsActor_TA:PRI")]
        public EngineGameReplicationInfoGameClass[] TaGameCameraSettingsActorTaPri { get; set; }

        [JsonProperty("Engine.Pawn:PlayerReplicationInfo")]
        public EnginePawnPlayerReplicationInfo EnginePawnPlayerReplicationInfo { get; set; }

        [JsonProperty("TAGame.Vehicle_TA:ReplicatedThrottle")]
        public long? TaGameVehicleTaReplicatedThrottle { get; set; }

        [JsonProperty("TAGame.Car_TA:TeamPaint")]
        public TaGameCarTaTeamPaint TaGameCarTaTeamPaint { get; set; }

        [JsonProperty("TAGame.CarComponent_TA:Vehicle")]
        public EnginePawnPlayerReplicationInfo TaGameCarComponentTaVehicle { get; set; }

        [JsonProperty("TAGame.CarComponent_Boost_TA:ReplicatedBoostAmount")]
        public long? TaGameCarComponentBoostTaReplicatedBoostAmount { get; set; }

        [JsonProperty("TAGame.CameraSettingsActor_TA:CameraYaw")]
        public long? TaGameCameraSettingsActorTaCameraYaw { get; set; }

        [JsonProperty("TAGame.CameraSettingsActor_TA:CameraPitch")]
        public long? TaGameCameraSettingsActorTaCameraPitch { get; set; }

        [JsonProperty("TAGame.CameraSettingsActor_TA:bUsingSecondaryCamera")]
        public bool? TaGameCameraSettingsActorTaBUsingSecondaryCamera { get; set; }

        [JsonProperty("TAGame.PRI_TA:SteeringSensitivity")]
        public double? TaGamePriTaSteeringSensitivity { get; set; }

        [JsonProperty("Engine.Actor:DrawScale")]
        public long? EngineActorDrawScale { get; set; }

        [JsonProperty("TAGame.CrowdActor_TA:GameEvent")]
        public EngineGameReplicationInfoGameClass[] TaGameCrowdActorTaGameEvent { get; set; }

        [JsonProperty("TAGame.CrowdManager_TA:GameEvent")]
        public EngineGameReplicationInfoGameClass[] TaGameCrowdManagerTaGameEvent { get; set; }

        [JsonProperty("TAGame.CrowdActor_TA:ModifiedNoise")]
        public double? TaGameCrowdActorTaModifiedNoise { get; set; }

        [JsonProperty("TAGame.GameEvent_TA:ReplicatedGameStateTimeRemaining")]
        public long? TaGameGameEventTaReplicatedGameStateTimeRemaining { get; set; }

        [JsonProperty("TAGame.GameEvent_Soccar_TA:RoundNum")]
        public long? TaGameGameEventSoccarTaRoundNum { get; set; }

        [JsonProperty("TAGame.Vehicle_TA:bDriving")]
        public bool? TaGameVehicleTaBDriving { get; set; }

        [JsonProperty("TAGame.CarComponent_TA:ReplicatedActive")]
        public long? TaGameCarComponentTaReplicatedActive { get; set; }

        [JsonProperty("TAGame.CarComponent_TA:Active")]
        public bool? TaGameCarComponentTaActive { get; set; }

        [JsonProperty("TAGame.CrowdActor_TA:ReplicatedOneShotSound")]
        public EngineGameReplicationInfoGameClass[] TaGameCrowdActorTaReplicatedOneShotSound { get; set; }

        [JsonProperty("TAGame.Vehicle_TA:ReplicatedSteer")]
        public long? TaGameVehicleTaReplicatedSteer { get; set; }

        [JsonProperty("TAGame.VehiclePickup_TA:ReplicatedPickupData")]
        public TaGameVehiclePickupTaReplicatedPickupData TaGameVehiclePickupTaReplicatedPickupData { get; set; }

        [JsonProperty("TAGame.CarComponent_Dodge_TA:DodgeTorque")]
        public InitialPosition TaGameCarComponentDodgeTaDodgeTorque { get; set; }

        [JsonProperty("TAGame.Ball_TA:HitTeamNum")]
        public long? TaGameBallTaHitTeamNum { get; set; }

        [JsonProperty("TAGame.Vehicle_TA:bReplicatedHandbrake")]
        public bool? TaGameVehicleTaBReplicatedHandbrake { get; set; }

        [JsonProperty("TAGame.GameEvent_Soccar_TA:bBallHasBeenHit")]
        public bool? TaGameGameEventSoccarTaBBallHasBeenHit { get; set; }

        [JsonProperty("TAGame.PRI_TA:MatchScore")]
        public long? TaGamePriTaMatchScore { get; set; }

        [JsonProperty("TAGame.PRI_TA:MatchShots")]
        public long? TaGamePriTaMatchShots { get; set; }

        [JsonProperty("TAGame.PRI_TA:MatchSaves")]
        public long? TaGamePriTaMatchSaves { get; set; }

        [JsonProperty("Engine.Actor:bCollideActors")]
        public bool? EngineActorBCollideActors { get; set; }

        [JsonProperty("Engine.Actor:bBlockActors")]
        public bool? EngineActorBBlockActors { get; set; }

        [JsonProperty("TAGame.Ball_TA:ReplicatedExplosionDataExtended")]
        public TaGameBallTaReplicatedExplosionDataExtended TaGameBallTaReplicatedExplosionDataExtended { get; set; }

        [JsonProperty("TAGame.GameEvent_Soccar_TA:ReplicatedScoredOnTeam")]
        public long? TaGameGameEventSoccarTaReplicatedScoredOnTeam { get; set; }

        [JsonProperty("Engine.TeamInfo:Score")]
        public long? EngineTeamInfoScore { get; set; }

        [JsonProperty("Engine.PlayerReplicationInfo:Score")]
        public long? EnginePlayerReplicationInfoScore { get; set; }

        [JsonProperty("TAGame.PRI_TA:MatchGoals")]
        public long? TaGamePriTaMatchGoals { get; set; }

        [JsonProperty("Engine.Actor:bHidden")]
        public bool? EngineActorBHidden { get; set; }

        [JsonProperty("TAGame.Car_TA:ReplicatedDemolish")]
        public TaGameCarTaReplicatedDemolish TaGameCarTaReplicatedDemolish { get; set; }
    }

    public partial class EnginePawnPlayerReplicationInfo
    {
        [JsonProperty("Active")]
        public bool Active { get; set; }

        [JsonProperty("ActorId")]
        public long ActorId { get; set; }
    }

    public partial class EnginePlayerReplicationInfoUniqueId
    {
        [JsonProperty("SteamID64")]
        public long SteamId64 { get; set; }

        [JsonProperty("SteamProfileUrl")]
        public SteamProfileUrl SteamProfileUrl { get; set; }

        [JsonProperty("Type")]
        public long Type { get; set; }

        [JsonProperty("Id")]
        public long[] Id { get; set; }

        [JsonProperty("PlayerNumber")]
        public long PlayerNumber { get; set; }
    }

    public partial class InitialPosition
    {
        [JsonProperty("X")]
        public long X { get; set; }

        [JsonProperty("Y")]
        public long Y { get; set; }

        [JsonProperty("Z")]
        public long Z { get; set; }
    }

    public partial class ProjectXGriXReservations
    {
        [JsonProperty("Unknown1")]
        public long Unknown1 { get; set; }

        [JsonProperty("PlayerId")]
        public EnginePlayerReplicationInfoUniqueId PlayerId { get; set; }

        [JsonProperty("PlayerName")]
        public PlayerName PlayerName { get; set; }

        [JsonProperty("Unknown2")]
        public long Unknown2 { get; set; }
    }

    public partial class TaGameBallTaReplicatedExplosionDataExtended
    {
        [JsonProperty("Unknown3")]
        public bool Unknown3 { get; set; }

        [JsonProperty("Unknown4")]
        public long Unknown4 { get; set; }

        [JsonProperty("Unknown1")]
        public bool Unknown1 { get; set; }

        [JsonProperty("ActorId")]
        public long ActorId { get; set; }

        [JsonProperty("Position")]
        public InitialPosition Position { get; set; }
    }

    public partial class TaGameCameraSettingsActorTaProfileSettings
    {
        [JsonProperty("FieldOfView")]
        public long FieldOfView { get; set; }

        [JsonProperty("Height")]
        public long Height { get; set; }

        [JsonProperty("Pitch")]
        public long Pitch { get; set; }

        [JsonProperty("Distance")]
        public long Distance { get; set; }

        [JsonProperty("Stiffness")]
        public double Stiffness { get; set; }

        [JsonProperty("SwivelSpeed")]
        public double SwivelSpeed { get; set; }

        [JsonProperty("TransitionSpeed")]
        public long TransitionSpeed { get; set; }
    }

    public partial class TaGameCarTaReplicatedDemolish
    {
        [JsonProperty("Unknown1")]
        public bool Unknown1 { get; set; }

        [JsonProperty("AttackerActorId")]
        public long AttackerActorId { get; set; }

        [JsonProperty("Unknown2")]
        public bool Unknown2 { get; set; }

        [JsonProperty("VictimActorId")]
        public long VictimActorId { get; set; }

        [JsonProperty("AttackerVelocity")]
        public InitialPosition AttackerVelocity { get; set; }

        [JsonProperty("VictimVelocity")]
        public InitialPosition VictimVelocity { get; set; }
    }

    public partial class TaGameCarTaTeamPaint
    {
        [JsonProperty("TeamNumber")]
        public long TeamNumber { get; set; }

        [JsonProperty("TeamColorId")]
        public long TeamColorId { get; set; }

        [JsonProperty("CustomColorId")]
        public long CustomColorId { get; set; }

        [JsonProperty("TeamFinishId")]
        public long TeamFinishId { get; set; }

        [JsonProperty("CustomFinishId")]
        public long CustomFinishId { get; set; }
    }

    public partial class TaGamePriTaClientLoadouts
    {
        [JsonProperty("Loadout1")]
        public Dictionary<string, long> Loadout1 { get; set; }

        [JsonProperty("Loadout2")]
        public Dictionary<string, long> Loadout2 { get; set; }
    }

    public partial class TaGamePriTaClientLoadoutsOnline
    {
        [JsonProperty("LoadoutOnline1")]
        public LoadoutOnline LoadoutOnline1 { get; set; }

        [JsonProperty("LoadoutOnline2")]
        public LoadoutOnline LoadoutOnline2 { get; set; }

        [JsonProperty("Unknown1")]
        public bool Unknown1 { get; set; }

        [JsonProperty("Unknown2")]
        public bool Unknown2 { get; set; }
    }

    public partial class LoadoutOnline
    {
        [JsonProperty("ProductAttributeLists")]
        public ProductAttributeList[][] ProductAttributeLists { get; set; }
    }

    public partial class ProductAttributeList
    {
        [JsonProperty("Unknown1")]
        public bool Unknown1 { get; set; }

        [JsonProperty("ClassIndex")]
        public long ClassIndex { get; set; }

        [JsonProperty("ClassName")]
        public ClassName ClassName { get; set; }

        [JsonProperty("HasValue")]
        public bool HasValue { get; set; }

        [JsonProperty("Value")]
        public long Value { get; set; }
    }

    public partial class TaGamePriTaPartyLeader
    {
        [JsonProperty("Type")]
        public long Type { get; set; }

        [JsonProperty("Id")]
        public long[] Id { get; set; }

        [JsonProperty("PlayerNumber")]
        public long PlayerNumber { get; set; }
    }

    public partial class TaGameRbActorTaReplicatedRbState
    {
        [JsonProperty("Sleeping")]
        public bool Sleeping { get; set; }

        [JsonProperty("Position")]
        public InitialPosition Position { get; set; }

        [JsonProperty("Rotation")]
        public Rotation Rotation { get; set; }

        [JsonProperty("LinearVelocity")]
        public InitialPosition LinearVelocity { get; set; }

        [JsonProperty("AngularVelocity")]
        public InitialPosition AngularVelocity { get; set; }
    }

    public partial class Rotation
    {
        [JsonProperty("X")]
        public double X { get; set; }

        [JsonProperty("Y")]
        public double Y { get; set; }

        [JsonProperty("Z")]
        public double Z { get; set; }
    }

    public partial class TaGameVehiclePickupTaReplicatedPickupData
    {
        [JsonProperty("Unknown1")]
        public bool Unknown1 { get; set; }

        [JsonProperty("ActorId")]
        public long ActorId { get; set; }

        [JsonProperty("Unknown2")]
        public bool Unknown2 { get; set; }
    }

    public partial class Level
    {
        [JsonProperty("Name")]
        public string Name { get; set; }
    }

    public partial class Properties
    {
        [JsonProperty("TeamSize")]
        public long TeamSize { get; set; }

        [JsonProperty("Team0Score")]
        public long Team0Score { get; set; }

        [JsonProperty("Team1Score")]
        public long Team1Score { get; set; }

        [JsonProperty("Goals")]
        public Goal[] Goals { get; set; }

        [JsonProperty("HighLights")]
        public HighLight[] HighLights { get; set; }

        [JsonProperty("PlayerStats")]
        public PlayerStat[] PlayerStats { get; set; }

        [JsonProperty("ReplayName")]
        public string ReplayName { get; set; }

        [JsonProperty("ReplayVersion")]
        public long ReplayVersion { get; set; }

        [JsonProperty("GameVersion")]
        public long GameVersion { get; set; }

        [JsonProperty("BuildID")]
        public long BuildId { get; set; }

        [JsonProperty("Changelist")]
        public long Changelist { get; set; }

        [JsonProperty("BuildVersion")]
        public string BuildVersion { get; set; }

        [JsonProperty("RecordFPS")]
        public long RecordFps { get; set; }

        [JsonProperty("KeyframeDelay")]
        public long KeyframeDelay { get; set; }

        [JsonProperty("MaxChannels")]
        public long MaxChannels { get; set; }

        [JsonProperty("MaxReplaySizeMB")]
        public long MaxReplaySizeMb { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("MapName")]
        public string MapName { get; set; }

        [JsonProperty("Date")]
        public string Date { get; set; }

        [JsonProperty("NumFrames")]
        public long NumFrames { get; set; }

        [JsonProperty("MatchType")]
        public string MatchType { get; set; }

        [JsonProperty("PlayerName")]
        public string PlayerName { get; set; }
    }

    public partial class Goal
    {
        [JsonProperty("Time")]
        public double Time { get; set; }

        [JsonProperty("PlayerName")]
        public string PlayerName { get; set; }

        [JsonProperty("PlayerTeam")]
        public long PlayerTeam { get; set; }
    }

    public partial class HighLight
    {
        [JsonProperty("Time")]
        public double Time { get; set; }

        [JsonProperty("CarName")]
        public string CarName { get; set; }

        [JsonProperty("BallName")]
        public string BallName { get; set; }
    }

    public partial class PlayerStat
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Platform")]
        public Platform Platform { get; set; }

        [JsonProperty("OnlineID")]
        public long OnlineId { get; set; }

        [JsonProperty("Team")]
        public long Team { get; set; }

        [JsonProperty("Score")]
        public long Score { get; set; }

        [JsonProperty("Goals")]
        public long Goals { get; set; }

        [JsonProperty("Assists")]
        public long Assists { get; set; }

        [JsonProperty("Saves")]
        public long Saves { get; set; }

        [JsonProperty("Shots")]
        public long Shots { get; set; }

        [JsonProperty("bBot")]
        public long BBot { get; set; }
    }

    public partial class Platform
    {
        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("Value")]
        public string Value { get; set; }
    }

    public partial class TickMark
    {
        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("Time")]
        public double Time { get; set; }
    }

    public enum SteamProfileUrl { HttpSteamcommunityComProfiles76561198029751331, HttpSteamcommunityComProfiles76561198355227431 };

    public enum PlayerName { Nathalie };

    public enum ClassName { TaGameProductAttributePaintedTa, TaGameProductAttributeUserColorTa };

    public partial struct EngineGameReplicationInfoGameClass
    {
        public bool? Bool;
        public long? Integer;
    }

    public partial class ReplayJson
    {
        public static ReplayJson FromJson(string json) => JsonConvert.DeserializeObject<ReplayJson>(json, RocketLeagueReplaysToDataSet.Data.RawReplayJsonClasses.Converter.Settings);
    }

    static class SteamProfileUrlExtensions
    {
        public static SteamProfileUrl? ValueForString(string str)
        {
            switch (str)
            {
                case "http://steamcommunity.com/profiles/76561198029751331": return SteamProfileUrl.HttpSteamcommunityComProfiles76561198029751331;
                case "http://steamcommunity.com/profiles/76561198355227431": return SteamProfileUrl.HttpSteamcommunityComProfiles76561198355227431;
                default: return null;
            }
        }

        public static SteamProfileUrl ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var str = serializer.Deserialize<string>(reader);
            var maybeValue = ValueForString(str);
            if (maybeValue.HasValue) return maybeValue.Value;
            throw new Exception("Unknown enum case " + str);
        }

        public static void WriteJson(this SteamProfileUrl value, JsonWriter writer, JsonSerializer serializer)
        {
            switch (value)
            {
                case SteamProfileUrl.HttpSteamcommunityComProfiles76561198029751331: serializer.Serialize(writer, "http://steamcommunity.com/profiles/76561198029751331"); break;
                case SteamProfileUrl.HttpSteamcommunityComProfiles76561198355227431: serializer.Serialize(writer, "http://steamcommunity.com/profiles/76561198355227431"); break;
            }
        }
    }

    static class PlayerNameExtensions
    {
        public static PlayerName? ValueForString(string str)
        {
            switch (str)
            {
                case "Nathalie": return PlayerName.Nathalie;
                default: return null;
            }
        }

        public static PlayerName ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var str = serializer.Deserialize<string>(reader);
            var maybeValue = ValueForString(str);
            if (maybeValue.HasValue) return maybeValue.Value;
            throw new Exception("Unknown enum case " + str);
        }

        public static void WriteJson(this PlayerName value, JsonWriter writer, JsonSerializer serializer)
        {
            switch (value)
            {
                case PlayerName.Nathalie: serializer.Serialize(writer, "Nathalie"); break;
            }
        }
    }

    static class ClassNameExtensions
    {
        public static ClassName? ValueForString(string str)
        {
            switch (str)
            {
                case "TAGame.ProductAttribute_Painted_TA": return ClassName.TaGameProductAttributePaintedTa;
                case "TAGame.ProductAttribute_UserColor_TA": return ClassName.TaGameProductAttributeUserColorTa;
                default: return null;
            }
        }

        public static ClassName ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var str = serializer.Deserialize<string>(reader);
            var maybeValue = ValueForString(str);
            if (maybeValue.HasValue) return maybeValue.Value;
            throw new Exception("Unknown enum case " + str);
        }

        public static void WriteJson(this ClassName value, JsonWriter writer, JsonSerializer serializer)
        {
            switch (value)
            {
                case ClassName.TaGameProductAttributePaintedTa: serializer.Serialize(writer, "TAGame.ProductAttribute_Painted_TA"); break;
                case ClassName.TaGameProductAttributeUserColorTa: serializer.Serialize(writer, "TAGame.ProductAttribute_UserColor_TA"); break;
            }
        }
    }

    public partial struct EngineGameReplicationInfoGameClass
    {
        public EngineGameReplicationInfoGameClass(JsonReader reader, JsonSerializer serializer)
        {
            Bool = null;
            Integer = null;

            switch (reader.TokenType)
            {
                case JsonToken.Integer:
                    Integer = serializer.Deserialize<long>(reader);
                    return;
                case JsonToken.Boolean:
                    Bool = serializer.Deserialize<bool>(reader);
                    return;
            }
            throw new Exception("Cannot convert EngineGameReplicationInfoGameClass");
        }

        public void WriteJson(JsonWriter writer, JsonSerializer serializer)
        {
            if (Bool != null)
            {
                serializer.Serialize(writer, Bool);
                return;
            }
            if (Integer != null)
            {
                serializer.Serialize(writer, Integer);
                return;
            }
            throw new Exception("Union must not be null");
        }
    }

    public static class Serialize
    {
        public static string ToJson(this ReplayJson self) => JsonConvert.SerializeObject(self, RocketLeagueReplaysToDataSet.Data.RawReplayJsonClasses.Converter.Settings);
    }

    internal class Converter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(SteamProfileUrl) || t == typeof(PlayerName) || t == typeof(ClassName) || t == typeof(EngineGameReplicationInfoGameClass) || t == typeof(SteamProfileUrl?) || t == typeof(PlayerName?) || t == typeof(ClassName?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (t == typeof(SteamProfileUrl))
                return SteamProfileUrlExtensions.ReadJson(reader, serializer);
            if (t == typeof(PlayerName))
                return PlayerNameExtensions.ReadJson(reader, serializer);
            if (t == typeof(ClassName))
                return ClassNameExtensions.ReadJson(reader, serializer);
            if (t == typeof(SteamProfileUrl?))
            {
                if (reader.TokenType == JsonToken.Null) return null;
                return SteamProfileUrlExtensions.ReadJson(reader, serializer);
            }
            if (t == typeof(PlayerName?))
            {
                if (reader.TokenType == JsonToken.Null) return null;
                return PlayerNameExtensions.ReadJson(reader, serializer);
            }
            if (t == typeof(ClassName?))
            {
                if (reader.TokenType == JsonToken.Null) return null;
                return ClassNameExtensions.ReadJson(reader, serializer);
            }
            if (t == typeof(EngineGameReplicationInfoGameClass))
                return new EngineGameReplicationInfoGameClass(reader, serializer);
            throw new Exception("Unknown type");
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var t = value.GetType();
            if (t == typeof(SteamProfileUrl))
            {
                ((SteamProfileUrl)value).WriteJson(writer, serializer);
                return;
            }
            if (t == typeof(PlayerName))
            {
                ((PlayerName)value).WriteJson(writer, serializer);
                return;
            }
            if (t == typeof(ClassName))
            {
                ((ClassName)value).WriteJson(writer, serializer);
                return;
            }
            if (t == typeof(EngineGameReplicationInfoGameClass))
            {
                ((EngineGameReplicationInfoGameClass)value).WriteJson(writer, serializer);
                return;
            }
            throw new Exception("Unknown type");
        }

        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new Converter(),
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
