using System;

namespace Framework.Reflection.InsertUpdateDelete
{
    [AttributeUsage(AttributeTargets.Class)]
    public class AtributoAncestralTabelaPropria : Attribute
    {
        // Fields
        private bool _tabelaPropria;

        // Properties
        public bool TabelaPropria
        {
            get
            {
                return this._tabelaPropria;
            }
            set
            {
                this._tabelaPropria = value;
            }
        }
    }
}