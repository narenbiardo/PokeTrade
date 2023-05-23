//obtain given commandline args
var commandLineArgs = Environment.GetCommandLineArgs();

switch (commandLineArgs[1])
{
    case "convertPK":
        string convertPKPath = commandLineArgs[2];
        int desirePKNumber = int.Parse(commandLineArgs[3]);
        ConvertPKUtilities.convertPK(convertPKPath, desirePKNumber);
        break;
    case "getPKInfo":
        string PKinfoPath = commandLineArgs[2];
        Utilities.getPKInfo(PKinfoPath, Utilities.getPKNumber(PKinfoPath));
        break;
    case "isPKCompatibleWithSAV":
        PKHeX.Core.SaveFile checkSAVCompatibilty =  Utilities.getSAV(commandLineArgs[2]);
        string checkPKCompatibiltyPath = commandLineArgs[3];
        int checkPKMCompatibiltyNumber = Utilities.getPKNumber(checkPKCompatibiltyPath);
        Console.Write(Utilities.isPKCompatibleWithSAV(checkSAVCompatibilty, Utilities.getPKM(checkPKCompatibiltyPath, checkPKMCompatibiltyNumber), checkPKMCompatibiltyNumber));
        //Console.Write(PKHeX.Core.SaveExtensions.IsCompatiblePKM(checkSAVCompatibilty, Utilities.getPKM(checkPKCompatibiltyPath, checkPKMCompatibiltyNumber)));
        break;
    case "tradePKToSAV":
        //obtain path gived in commandline args
        string savPathTrade = commandLineArgs[2];
        string insertPK6Path = commandLineArgs[3];
        string removePK6Path = commandLineArgs[4];

        //obtain sav and pokemon boxes
        var savTrade = Utilities.getSAV(savPathTrade);
        var boxData = savTrade.BoxData;
        //obtain pk6
        var insertPK6 = Utilities.getPK6(insertPK6Path);
        var removePK6 = Utilities.getPK6(removePK6Path);

        //trade pokemon in the box
        savTrade.BoxData = TradePKToSAVUtilities.tradePK6(boxData, insertPK6, removePK6);

        //overwrite sav
        File.WriteAllBytes(savPathTrade, savTrade.Write());
        break;
    default:
        Console.Write("Xd");
        break;
}