using System;


namespace Framework.Reflection.InsertUpdateDelete
{
    public class AtributoBancoDados : Attribute
    {
        // Fields
        private bool _atributoBD;

        // Properties
        public bool AtributoBD
        {
            get
            {
                return this._atributoBD;
            }
            set
            {
                this._atributoBD = value;
            }
        }
    }
}
 
