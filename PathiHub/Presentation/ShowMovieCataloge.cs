
public class ShowMovieCataloge
{

    public static void PresentateTabel()
    {
        
         Console.WriteLine(@"

___  ___           _        _____       _        _                  
|  \/  |          (_)      /  __ \     | |      | |                 
| .  . | _____   ___  ___  | /  \/ __ _| |_ __ _| | ___   __ _  
| |\/| |/ _ \ \ / / |/ _ \ | |    / _` | __/ _` | |/ _ \ / _` |
| |  | | (_) \ V /| |  __/ | \__/\ (_| | || (_| | | (_) | (_| |
\_|  |_/\___/ \_/ |_|\___|  \____/\__,_|\__\__,_|_|\___/ \__, |
                                                          __/ |     
                                                         |___/     
");

         Console.WriteLine("--------------------------------------------------------------------------------");
         Console.WriteLine("This our movie Catalog");
         Console.WriteLine("--------------------------------------------------------------------------------");
         
         MovieCatalogePrinter.TabelPrinter();
         
         
    }
    
   
}