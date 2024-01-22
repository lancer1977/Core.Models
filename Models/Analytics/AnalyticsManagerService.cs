using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PolyhydraGames.Core.Interfaces;

namespace PolyhydraGames.Core.Models.Analytics
{
    /// <summary>
    /// Service to handle communicating with multiple analytics classes.
    /// </summary>
    ///  
    public class AnalyticsManager : IAnalyticsManager{
        public IEnumerable<IAnalytics> Services => _services;
        private readonly List<IAnalytics> _services;

        public AnalyticsManager() => _services = new List<IAnalytics> ();

        /// <summary>
        /// Adds the service to the manager.
        /// </summary>
        /// <param name="analytics">Analytics Service.</param>
        public void AddService(IAnalytics analytics)=> _services.Add (analytics);
		
        /// <summary>
        /// Runs an action on all registered analytics implementations.
        /// </summary>
        /// <param name="action">Action.</param>
        public void RunAction(Action<IAnalytics> action){
            Task.Run (() => {
                foreach (var item in Services)
                    action (item);
            });
        }

    }
}