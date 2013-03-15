namespace SciSharp.Language.Grammars.BottomUp
{
    /// <summary>
    /// Representa la transici�n de un estado a otro a partir de un s�mbolo.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Goto<T> where T : Node, new()
    {
        public Goto(LrState<T> origin, Def<T> symbol, LrState<T> destiny)
        {
            Origin = origin;
            Symbol = symbol;
            Destination = destiny;
        }

        /// <summary>
        /// Estado donde se define el Goto.
        /// </summary>
        public LrState<T> Origin { get; set; }

        /// <summary>
        /// S�mbolo por el que se salta.
        /// </summary>
        public Def<T> Symbol { get; set; }

        /// <summary>
        /// Estado de Destino del Goto
        /// </summary>
        public LrState<T> Destination { get; set; }
    }
}
