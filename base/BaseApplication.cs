using System;
using System.Collections.Generic;

namespace Project.Base {

    abstract class BaseApplication {

        // Program variables
        private bool running = false;
        private readonly Dictionary<string, Service> services = new Dictionary<string, Service>();

        // Called on load/unload
        protected abstract void Load();
        protected abstract void Unload();

        // Returns whether the application is running
        public bool IsRunning() {
            return running;
        }

        // Loads the application and its services
        public void Start() {
            if (IsRunning()) {
                throw new Exception("Application is already running.");
            }

            // Set running to true
            running = true;

            // Load app
            Load();

            // Load services
            foreach (Service service in services.Values) {
                service.Load();
            }
        }

        // Unload all services and the application
        public void Stop() {
            if (!IsRunning()) {
                throw new Exception("Application is not running.");
            }

            // Unload services
            foreach (Service service in services.Values) {
                service.Unload();
            }

            // Unload app
            Unload();

            // Set running to false to stop any running loops
            running = false;
        }

        // Register a service
        public void RegisterService(Service service) {
            services.Add(service.GetHandle(), service);
        }

        // Returns a service by its handle
        public T GetService<T>(string handle) {
            // Return empty value if service does not exist
            if (!services.TryGetValue(handle, out Service service)) {
                return default;
            }

            // Cast service and return
            return (T) Convert.ChangeType(service, typeof(T));
        }

    }

}
