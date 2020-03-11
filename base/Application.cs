using System;
using System.Collections.Generic;
using Project.Enums;
using Project.Helpers;

namespace Project.Base {

    abstract class Application {

        // Program variables
        private bool running = false;
        private Dictionary<string, Service> services = new Dictionary<string, Service>();

        // Called on load/unload
        protected abstract void Load();
        protected abstract void Unload();

        // Returns whether the application is running
        public bool IsRunning() {
            return this.running;
        }

        // Loads the application and its services
        public void Start() {
            if (this.IsRunning()) {
                throw new Exception("Application is already running.");
            }

            // Set running to true
            this.running = true;

            // Load app
            this.Load();

            // Load services
            foreach (Service service in services.Values) {
                service.Load();
            }
        }

        // Unload all services and the application
        public void Stop() {
            if (!this.IsRunning()) {
                throw new Exception("Application is not running.");
            }

            // Unload services
            foreach (Service service in services.Values) {
                service.Unload();
            }

            // Unload app
            this.Unload();

            // Set running to false to stop any running loops
            this.running = false;
        }

        // Register a service
        public void RegisterService(Service service) {
            this.services.Add(service.getHandle(), service);
        }

        // Returns a service by its handle
        public T GetService<T>(string handle) {
            Service service;

            // Return empty value if service does not exist
            if (!services.TryGetValue(handle, out service)) {
                return default(T);
            }

            // Cast service and return
            return (T) Convert.ChangeType(service, typeof(T));
        }

    }

}
