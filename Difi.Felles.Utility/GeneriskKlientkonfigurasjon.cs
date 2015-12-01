﻿using System;
using System.Diagnostics;
using System.IO;

namespace Difi.Felles.Utility
{
    /// <summary>
    /// Inneholder konfigurasjon for sending av digital post.
    /// </summary> 
    public abstract class GeneriskKlientkonfigurasjon
    {
        public AbstraktMiljø Miljø { get; set; }

        /// <summary>
        /// Angir host som skal benyttes i forbindelse med bruk av proxy. Både ProxyHost og ProxyPort må spesifiseres for at en proxy skal benyttes. 
        public string ProxyHost { get; set; }

        /// <summary>
        /// Angir schema ved bruk av proxy. Standardverdien er 'https'.
        /// </summary>
        public string ProxyScheme { get; set; }

        /// <summary>
        /// Angir portnummeret som skal benyttes i forbindelse med bruk av proxy. Både ProxyHost og ProxyPort må spesifiseres for at en proxy skal benyttes.
        /// </summary>
        public int ProxyPort { get; set; }

        /// <summary>
        /// Angir timeout for komunikasjonen fra og til meldingsformindleren. Default tid er 30 sekunder.
        /// </summary>
        public int TimeoutIMillisekunder { get; set; }

        /// <summary>
        /// Eksponerer et grensesnitt for logging hvor brukere kan integrere sin egen loggefunksjonalitet eller en tredjepartsløsning som f.eks log4net. For bruk, angi en annonym funksjon med 
        /// følgende parametre: severity, konversasjonsid, metode, melding.  
        /// </summary>
        public Action<TraceEventType, Guid?, string, string> Logger { get; set; }

        public bool BrukProxy
        {
            get
            {
                return !string.IsNullOrWhiteSpace(ProxyHost) && ProxyPort > 0;
            }
        }
        
        public bool LoggXmlTilFil { get; set; }

        public string StandardLoggSti { get; set; }

        protected GeneriskKlientkonfigurasjon(AbstraktMiljø miljø)
        {
            Miljø = miljø;
            ProxyHost = null;
            ProxyScheme = "https";
            TimeoutIMillisekunder = (int)TimeSpan.FromSeconds(30).TotalMilliseconds;
            LoggXmlTilFil = false;
            StandardLoggSti = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Digipost");
        }
    }
}
