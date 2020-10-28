using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalManager.Client.Controlers
{
    public class PageController
    {
        #region Constantes
        #endregion Constantes

        #region Atributos
        #endregion Atributos

        #region Construtores

        private static PageController _i;

        public static PageController i
        {
            get
            {
                if (_i == null)
                {
                    _i = new PageController();
                }

                return _i;
            }
        }

        private PageController()
        {
        }

        #endregion Construtores

        #region Métodos

        public RenderFragment Content { get; set; }

        #endregion Métodos

        #region Eventos
        #endregion Eventos
    }
}
