using System.Reflection.Metadata.Ecma335;

public class Company
{
    Dictionary<int, Implant> _implants = new();



    /* 
        Search the implant that has been on "broken" state most time : 
            - Sorted Set (1 DS for each point 4/5)  N
            - Search Algorithm ( ?? need to search in the single dictionary...)
            - Sorting DS + (obeserver? 1 DS for each point 4/5) 
            - MaxHeap (1 DS for each point 4/5)

    */

    /* ---------- First Solution SortedSet ---------- */
    
    /*
     ------------------------------------------------------------------------------------------------------------------------------------------------------
        time complexity O(logn) per inserimenti <<
        time complexit O(1) per ricerca massimo << 
        !!!! A seguito di una modifica O(n) per ciclare tutto il sorted set e O(logn) per aggiornare ogni elemento che ha avuto una modifica (troppo alta) !!!!
            foreach(element in sortedSet){
                if(stat is aggiornato){
                    sortedSet.Remove(elemnt);
                    sortedSet.Add(UpdatedElement); 
                    //dove mi salvo questo elemento cambiato? lo devo cercare? come lo cerco? dovrei farlo ad ogni cambiamento,dovrei quindi pagare O(n) + O(logn) 
                    // ad ogni modifica. !! N.B: non so se la complessità sale ad O(n) + O(logn) oppure ad O(n logn) 

                }
            }
        
        Spase Complexity O() A questo punto non mi interessa nemmeno saperla, visto che la complessità per aggiornarlo sarà molto elevata 
     ------------------------------------------------------------------------------------------------------------------------------------------------------ 

    
        ----- Un oggetto SortedSet<T> mantiene un 
        ordinamento senza influire sulle prestazioni 
        durante l'inserimento e l'eliminazione degli 
        elementi. -----

        !!  La modifica dei valori di ordinamento degli elementi esistenti non è supportata e può causare un comportamento imprevisto. !!
        >> una soluzione sarebbe quella di rimuovere, modificare e reinserire (nota positiva in tutti i casi avrò O(n) (dove n è il numero di impianti, devo infatti aggiornarli
            necessariamente tutti, o se tenessi un log dovrei comunque scorrere tutto il sortedSet)
            e avverrebbe nel caso in cui tutti gli impianti sono stati modificati.) (una domanda potrebbe essere conviene fare l'operazione solo quando viene richiesta?)
        
        !! Dovrei necessariamente implementare la classe implant come implementatrice di Icomparable, per poter avere un sort basato sul numero di volte in cui 
            l'implant è stato guasto, inoltre si presenterebbe un altro problema !!! come faccio ad implementare un Icompareble in più per gli auto implant (seconda DS)
        >> Soluzione: la classe padre implementa Icomparable basata su "chi è stato più rotto" ==> la classe figlia AutoImplant implementerà Icompareble ma con la logica
            per il sort degli impianti automatici (punto 5) n.b il primo sortedSet sarà di tipo "Implant" il secondo di tipo "AutoImplant"
            !! dovrei però creare 2 classi per il comparer "public class ImpiantiComparer : IComparer<Impianti>" e "public class ImpiantiAutomaticiComparer : IComparer<ImpiantiAutomatici>"
            >> SortedSet<T>(IComparer<T>) ==> Inizializza una nuova istanza della classe SortedSet<T> che usa un operatore di confronto specificato.
    */



    /* ---------- Second Solution Algorithms ---------- */

    /*
        ------------------------------------------------------------------------------------------------------------------------------------------------------
        time complexity O(n^2) ==> HowManyTimeBroken comporta un ulteriore ciclo che itera tutta la lista (anche se ipoteticamente utilizzassi un'altra
        struttura dati per salvarmi il log, dovrei comunque ciclarla tutta per prendere TUTTI gli stati di "guasto" quindi comunque O(n) )
        !! Complessità troppo alta << devo migliorare l'algoritmo ?? ho un modo ?? a questo punto utilizzo direttamente un sorted Array !! 
        space complexity O() 
        ------------------------------------------------------------------------------------------------------------------------------------------------------
    
        per un algoritmo di ricerca del massimo (punto 4: l'impianto che nel tempo è stato più spesso broken): 
            maxElemnt = dictionary.get(primoElmnt); 
            maxVolteRotto = maxElemnt.quanteVolteRotto;
            foreach(elemnt in dictionary){
                if(elemnt.quanteVolteRotto > maxVolteRotto) { 
                    maxVolteRotto = elemnt.quanteVolteRotto; 
                    maxElemnt = elemnt;
                }
            }

    */
    
    /* 
    
        ---------- O(n^2) time complexity too much hight ---------- 

    public Implant SearchMostTimeBrokenImplant()
    {
        Implant mostBrokenImplant = new(); // come prendo il primo elemento da un dictionary? 
        int MaxTimeBroken= mostBrokenImplant.HowManyTimeBroken(
        foreach(var implant in implants.Values){
            if(implant.HowManyTimeBroken() > MaxTimeBroken){
                mostBrokenImplant = implant; 
            }
       
        return mostBrokenImplant; 
    }

    */


}