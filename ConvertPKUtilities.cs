class ConvertPKUtilities{
    public static PKHeX.Core.PK2 convertPK1ToPK2(PKHeX.Core.PK1 PK1){
        return PK1.ConvertToPK2();
    }

    public static PKHeX.Core.PK7 convertPK1ToPK7(PKHeX.Core.PK1 PK1){
        return PK1.ConvertToPK7();
    }

    public static PKHeX.Core.PK1 convertPK2ToPK1(PKHeX.Core.PK2 PK2){
        return PK2.ConvertToPK1();
    }

    public static PKHeX.Core.PK7 convertPK2ToPK7(PKHeX.Core.PK2 PK2){
        return PK2.ConvertToPK7();
    }

    public static PKHeX.Core.PK4 convertPK3ToPK4(PKHeX.Core.PK3 PK3){
        return PK3.ConvertToPK4();
    }

    public static PKHeX.Core.PK5 convertPK4ToPK5(PKHeX.Core.PK4 PK4){
        return PK4.ConvertToPK5();
    }

    public static PKHeX.Core.PK6 convertPK5ToPK6(PKHeX.Core.PK5 PK5){
        return PK5.ConvertToPK6();
    }

    public static PKHeX.Core.PK7 convertPK6ToPK7(PKHeX.Core.PK6 PK6){
        return PK6.ConvertToPK7();
    }
    public static PKHeX.Core.PK8 convertPK7ToPK8(PKHeX.Core.PK7 PK7){
        return PK7.ConvertToPK8();
    }

    public static PKHeX.Core.PK9 convertPK8ToPK9(PKHeX.Core.PK8 PK8){
        return PK8.ConvertToPK9();
    }

    public static void convertPK(string convertPKPath, int desirePKNumber){
        int currentPKNumber = Utilities.getPKNumber(convertPKPath);
        int initialPKNumber = currentPKNumber;

        PKHeX.Core.PK1 PK1 = new PKHeX.Core.PK1();
        PKHeX.Core.PK2 PK2 = new PKHeX.Core.PK2();
        PKHeX.Core.PK3 PK3 = new PKHeX.Core.PK3();
        PKHeX.Core.PK4 PK4 = new PKHeX.Core.PK4();
        PKHeX.Core.PK5 PK5 = new PKHeX.Core.PK5();
        PKHeX.Core.PK6 PK6 = new PKHeX.Core.PK6();
        PKHeX.Core.PK7 PK7 = new PKHeX.Core.PK7();
        PKHeX.Core.PK8 PK8 = new PKHeX.Core.PK8();
        PKHeX.Core.PK9 PK9 = new PKHeX.Core.PK9();

        while(currentPKNumber != desirePKNumber){
            switch(currentPKNumber){
                    case 1:
                        if(initialPKNumber == currentPKNumber){
                            PK1 = Utilities.getPK1(convertPKPath);
                        }
                        switch (desirePKNumber){
                            case 2:
                                PK2 = convertPK1ToPK2(PK1);
                                currentPKNumber = 2;
                                break;
                            case 7:
                                PK7 = convertPK1ToPK7(PK1);
                                currentPKNumber = 7;
                                break;
                            default:
                                break;
                        }
                        break;
                    case 2:
                        if(initialPKNumber == currentPKNumber){
                            PK2 = Utilities.getPK2(convertPKPath);
                        }
                        switch (desirePKNumber){
                            case 1:
                                PK1 = convertPK2ToPK1(PK2);
                                currentPKNumber = 1;
                                break;
                            case 7:
                                PK7 = convertPK2ToPK7(PK2);
                                currentPKNumber = 7;
                                break;
                            default:
                                break;
                        }
                        break;
                    case 3:
                        if(initialPKNumber == currentPKNumber){
                            PK3 = Utilities.getPK3(convertPKPath);
                        }
                        PK4 = convertPK3ToPK4(PK3);
                        currentPKNumber = 4;
                        break;
                    case 4:
                        if(initialPKNumber == currentPKNumber){
                            PK4 = Utilities.getPK4(convertPKPath);
                        }
                        PK5 = convertPK4ToPK5(PK4);
                        currentPKNumber = 5;
                        break;
                    case 5:
                        if(initialPKNumber == currentPKNumber){
                            PK5 = Utilities.getPK5(convertPKPath);
                        }
                        PK6 = convertPK5ToPK6(PK5);
                        currentPKNumber = 6;
                        break;
                    case 6:
                        if(initialPKNumber == currentPKNumber){
                            PK6 = Utilities.getPK6(convertPKPath);
                        }
                        PK7 = convertPK6ToPK7(PK6);
                        currentPKNumber = 7;
                        break;
                    case 7:
                        if(initialPKNumber == currentPKNumber){
                            PK7 = Utilities.getPK7(convertPKPath);
                        }
                        PK8 = convertPK7ToPK8(PK7);
                        currentPKNumber = 8;
                        break;
                    case 8:
                        if(initialPKNumber == currentPKNumber){
                            PK8 = Utilities.getPK8(convertPKPath);
                        }
                        PK9 = convertPK8ToPK9(PK8);
                        currentPKNumber = 9;
                        break;
                    default:
                        break;
                }
        }

        switch (currentPKNumber)
        {
            case 1:
                File.WriteAllBytes(@"..\Shared\converted.pk" + currentPKNumber.ToString(), PK1.Data);
                break;
            case 2:
                File.WriteAllBytes(@"..\Shared\converted.pk" + currentPKNumber.ToString(), PK2.Data);
                break;
            case 3:
                File.WriteAllBytes(@"..\Shared\converted.pk" + currentPKNumber.ToString(), PK3.Data);
                break;
            case 4:
                File.WriteAllBytes(@"..\Shared\converted.pk" + currentPKNumber.ToString(), PK4.Data);
                break;
            case 5:
                File.WriteAllBytes(@"..\Shared\converted.pk" + currentPKNumber.ToString(), PK5.Data);
                break;
            case 6:
                File.WriteAllBytes(@"..\Shared\converted.pk" + currentPKNumber.ToString(), PK6.Data);
                break;
            case 7:
                File.WriteAllBytes(@"..\Shared\converted.pk" + currentPKNumber.ToString(), PK7.Data);
                break;
            case 8:
                File.WriteAllBytes(@"..\Shared\converted.pk" + currentPKNumber.ToString(), PK8.Data);
                break;
            case 9:
                File.WriteAllBytes(@"..\Shared\converted.pk" + currentPKNumber.ToString(), PK9.Data);
                break;
        }
        File.Delete(convertPKPath);
    }

}