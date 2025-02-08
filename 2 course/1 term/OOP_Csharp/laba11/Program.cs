namespace laba11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 1st
            File.WriteAllText("Reflection.txt", string.Empty);

            Reflector.NameWrite("laba11.Reflector");
            Reflector.PublicMethodsEnumerationWrite("laba11.Reflector");
            Reflector.FieldsAndPropsWrite("laba11.Reflector");

            Reflector.InterfacesOfClassWrite("laba9.GeometricFigure");
            Reflector.OutputDataByClassNameWrite("laba9.GeometricFigure", "currentClassName");
            Reflector.Invoke("laba9.GeometricFigure", "dosomething");

            Reflector.Create(5, 6);
            #endregion
        }
    }
}
