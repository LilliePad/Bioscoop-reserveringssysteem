using System;
using System.Collections.Generic;
using Project.Enums;
using Project.Helpers;

namespace Project.Base {

    abstract class Application {

        // Program variables
        private bool running = false;
        private Dictionary<string, Service> services = new Dictionary<string, Service>();

        protected abstract void Load();
        protected abstract void Unload();

        public bool IsRunning() {
            return this.running;
        }

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

            this.running = false;
            System.Environment.Exit(1);
        }

        public void registerService(Service service) {
            this.services.Add(service.getHandle(), service);
        }

        public T getService<T>(string handle) {
            Service service;

            if (!services.TryGetValue(handle, out service)) {
                return default(T);
            }

            return (T)Convert.ChangeType(service, typeof(T));
        }

    }

}
