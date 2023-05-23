class Utilities{
    public static PKHeX.Core.SaveFile getSAV(string path){
        return PKHeX.Core.SaveUtil.GetVariantSAV(path);
    }

    public static int getPKNumber(string PKpath){
        return int.Parse(PKpath.Substring(PKpath.Length - 1, 1)[0].ToString());
    }

    public static PKHeX.Core.PK1 getPK1(string pathPK1){  
        var dataPK1 = File.ReadAllBytes(pathPK1);
        var PK1 = new PKHeX.Core.PK1(dataPK1);
        return PK1;
    }

    public static PKHeX.Core.PK2 getPK2(string pathPK2){  
        var dataPK2 = File.ReadAllBytes(pathPK2);
        var PK2 = new PKHeX.Core.PK2(dataPK2);
        return PK2;
    }
    public static PKHeX.Core.PK3 getPK3(string pathPK3){  
        var dataPK3 = File.ReadAllBytes(pathPK3);
        var PK3 = new PKHeX.Core.PK3(dataPK3);
        return PK3;
    }

    public static PKHeX.Core.PK4 getPK4(string pathPK4){  
        var dataPK4 = File.ReadAllBytes(pathPK4);
        var PK4 = new PKHeX.Core.PK4(dataPK4);
        return PK4;
    }

    public static PKHeX.Core.PK5 getPK5(string pathPK5){  
        var dataPK5 = File.ReadAllBytes(pathPK5);
        var PK5 = new PKHeX.Core.PK5(dataPK5);
        return PK5;
    }
    public static PKHeX.Core.PK6 getPK6(string pathPK6){  
    var dataPK6 = File.ReadAllBytes(pathPK6);
    var PK6 = new PKHeX.Core.PK6(dataPK6);
    return PK6;
    }
    public static PKHeX.Core.PK7 getPK7(string pathPK7){  
        var dataPK7 = File.ReadAllBytes(pathPK7);
        var PK7 = new PKHeX.Core.PK7(dataPK7);
        return PK7;
    }
    public static PKHeX.Core.PK8 getPK8(string pathPK8){  
        var dataPK8 = File.ReadAllBytes(pathPK8);
        var PK8 = new PKHeX.Core.PK8(dataPK8);
        return PK8;
    }

    public static PKHeX.Core.PK9 getPK9(string pathPK9){  
        var dataPK9 = File.ReadAllBytes(pathPK9);
        var PK9 = new PKHeX.Core.PK9(dataPK9);
        return PK9;
    }

    public static PKHeX.Core.PKM getPKM(string pathPKM, int PKNumber){
        switch(PKNumber){
            case 1:
                return Utilities.getPK1(pathPKM);
            case 2:
                return Utilities.getPK2(pathPKM);
            case 3:
                return Utilities.getPK3(pathPKM);
            case 4:
                return Utilities.getPK4(pathPKM);
            case 5:
                return Utilities.getPK5(pathPKM);
            case 6:
                return Utilities.getPK6(pathPKM);
            case 7:
                return Utilities.getPK7(pathPKM);
            case 8:
                return Utilities.getPK8(pathPKM);
            case 9:
                return Utilities.getPK9(pathPKM);
            default:
                return null;
        }
    }

    public static void getPKInfo(string PKPath, int PKNumber){
        PKHeX.Core.Language.GetAvailableGameLanguages(1);
        switch (PKNumber)
        {
            case 1:
                //PKHeX.Core.PK1 PK1 = getPK1("../Shared/063 - ABRA - 3172.pk1");
                byte[] dataPK1 = File.ReadAllBytes(PKPath);
                PKHeX.Core.PKM PKM2;
                PKHeX.Core.PokeList1 pokeList1 = new PKHeX.Core.PokeList1(dataPK1);                           
                PKHeX.Core.PK1 PK1 = pokeList1.Pokemon[0];
                PKHeX.Core.PKM PKM = PK1;
                //Interesante para conseguir el pokemon y luego transformarlo y PKM2.Extension
                PKHeX.Core.FileUtil.TryGetPKM(dataPK1, out PKM2, "", null);

                //PKHeX.Core.PK1 PK1New = new PKHeX.Core.PKM(dataPK1);
                //var dataPK1 = File.ReadAllBytes("../Shared/converted.pk8");
                //var PK1 = new PKHeX.Core.PK8(dataPK1);
                
                Console.Write("PKNumber: " + PKNumber
                + "\nSpecies Name: " + PKHeX.Core.SpeciesName.GetSpeciesName(PK1.Species, 2)
                + (PK1.IsNicknamed ? "\nNickname: " + PK1.Nickname : "\nNONICKNAME")
                + "\nEXP: " + PK1.EXP
                + "\nLevel: " + PK1.CurrentLevel
                + "\nLanguage: " + Enum.GetName(typeof(PKHeX.Core.LanguageID), PK1.Language)
                + "\nStatHP: " + PK1.Stat_HPMax
                + "\nStatAtk: " + PK1.Stat_ATK
                + "\nStatDef: " + PK1.Stat_DEF
                + "\nStatSpc: " + PK1.Stat_SPC
                + "\nStatSpe: " + PK1.Stat_SPE
                + "\nHiddenPowerType: " + PKM.Extension
                + " " + " c " + PKM2.Extension + " xd " + PKHeX.Core.EntityFileExtension.GetExtensions(3)[0]);
               
                break;
            default:
                break;
        }
    }

    public static bool isPKCompatibleWithSAV(PKHeX.Core.SaveFile SAV, PKHeX.Core.PKM PKM, int PKNumber){
        switch (SAV.Generation)
        {
            case 1:
                if(PKM.Generation == 1 && PKNumber == 1){
                    return true;
                }else{
                    return false;
                }
                break;
            case 2:
                if(PKM.Generation < 3 && PKNumber < 3){
                    return true;
                }else{
                    return false;
                }
                break;
            case 3:
                if(PKM.Generation < 4 && PKNumber == 3){
                    return true;
                }else{
                    return false;
                }
                break;
            case 4:
                if(PKM.Generation < 5 && (PKNumber > 2 && PKNumber < 5)){
                    return true;
                }else{
                    return false;
                }
                break;
            case 5:
                if(PKM.Generation < 6 && (PKNumber > 2 && PKNumber < 6)){
                    return true;
                }else{
                    return false;
                }
                break;
            case 6:
                if(PKM.Generation < 7 && (PKNumber > 2 && PKNumber < 7)){
                    return true;
                }else{
                    return false;
                }
                break;
            case 7:
                if(PKM.Generation < 8 && PKNumber < 8){
                    return true;
                }else{
                    return false;
                }
                break;
            case 8:
                //Esto no es verdad, es provicional
                if(PKM.Generation < 9 && PKNumber < 9){
                    return true;
                }else{
                    return false;
                }
                break;
            case 9:
                //Pokemon Home no está abierto, creo que PKHex no permite otro que no sea PK9
                if(PKNumber == 9){
                    return true;
                }else{
                    return false;
                }
                break;
            default:
                break;
        }
        return false;
    }
    
}