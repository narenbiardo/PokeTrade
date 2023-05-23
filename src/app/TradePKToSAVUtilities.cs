class TradePKToSAVUtilities{
    /*
    Trade-only Pokemon evolution list
    Each entry is an array of three integers:
        -First integer is the species ID of the Pokemon that can evolve by trade
        -Second integer is the species ID of the resulting evolved form
        -Third integer is the requirement for the evolution to occur:
            *If the value is 0, there is no requirement
            *If the value is -1, the Pokemon must be traded with a specific Pokemon species to evolve
            *If the value is bigger than 0, the Pokemon must be traded while holding a specific item (whose ID is the value of the requirement)
    */
    private static int[][] tradeEvolutionPokemons = new int[][] {
        new int[] {61, 186, 1},
        new int[] {64, 65, 0},
        new int[] {67, 68, 0},
        new int[] {75, 76, 0},
        new int[] {79, 199, 1},
        new int[] {93, 94, 0},
        new int[] {95, 208, 1},
        new int[] {112, 464, 1},
        new int[] {117, 230, 1},
        new int[] {123, 212, 1},
        new int[] {125, 466, 1},
        new int[] {126, 467, 1},
        new int[] {137, 233, 1},
        new int[] {233, 474, 1},
        new int[] {349, 350, 1},
        new int[] {356, 477, 1},
        new int[] {366, 367, 1},
        new int[] {525, 526, 0},
        new int[] {533, 534, 0},
        new int[] {588, 589, -1},
        new int[] {616, 617, -1},
        new int[] {682, 683, 1},
        new int[] {684, 685, 1},
        new int[] {708, 709, 0},
        new int[] {710, 711, -1}
    };
    private static int tradeEvolutionPokemonsLength = tradeEvolutionPokemons.GetLength(0);

    public static bool isPK6TradeEvolution(PKHeX.Core.PK6 PK6){
        var finded = false;
        var i = 0;

        while(!finded && i < tradeEvolutionPokemonsLength){
            
            if(tradeEvolutionPokemons[i][0] == PK6.Species){
                finded = true;
            }
            i += 1;
        }
        return finded;
    }

    public static PKHeX.Core.PK6 evolvePK6(PKHeX.Core.PK6 PK6){
        var finded = false;
        var i = 0;

        while(!finded && i < tradeEvolutionPokemonsLength){
            if(tradeEvolutionPokemons[i][0] == PK6.Species){
                switch (tradeEvolutionPokemons[i][2])
                {
                case -1:
                    // hacer algo especial
                    switch (tradeEvolutionPokemons[i][0])
                        {
                        case 588:
                            // hacer algo especial
                            break;
                        case 616:
                            // hacer algo especial
                            break;
                        case 710:
                            // hacer algo especial
                            break;
                        }
                    break;
                case 0:
                    // caso de 0, o sea que no tenga evo "especial"
                    PK6.Species = (ushort)tradeEvolutionPokemons[i][1];
                    break;
                }
                finded = true;
            }
            i += 1;
        }
        return PK6;
    }

    public static IList<PKHeX.Core.PKM> tradePK6(IList<PKHeX.Core.PKM> boxData, PKHeX.Core.PK6 insertPK6, PKHeX.Core.PK6 removePK6){
        for (int i = 0; i < boxData.Count-1; i++){
            if(boxData[i].PID == removePK6.PID){
                if(isPK6TradeEvolution(insertPK6)){
                    insertPK6 = evolvePK6(insertPK6);
                    if(!insertPK6.IsNicknamed){
                        insertPK6.Nickname = PKHeX.Core.SpeciesName.GetSpeciesName(insertPK6.Species, insertPK6.Language);
                        //insertPK6.Trade();
                    }
                }
                boxData[i] = insertPK6;
            }
        }
        return boxData;
    }
}