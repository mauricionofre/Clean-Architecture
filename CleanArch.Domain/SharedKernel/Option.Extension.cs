namespace CleanArch.Domain
{
    /// <summary>
    ///  Extens�o da classe Option para implementar m�todos �teis na representa��o um objeto de retorno que pode ser nulo.
    /// </summary>
    public static class Option
    {
        /// <summary>
        ///  M�todo que retorna uma nova instancia de Option com base no param�tro value
        /// </summary>
        /// <param name="value">� o resultado da opera��o</param>
        public static Option<T> Of<T>(T value) => new Option<T>(value, value != null);
    }
}