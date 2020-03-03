using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Base {

    abstract class Application {

        // Program variables
        private static Application instance;
        private bool running = false;

        protected abstract void Load();
        protected abstract void Unload();

        protected static void Run(Application app) {
            instance = app;
            instance.Start();
        }

        public static Application GetInstance() {
            return instance;
        }

        public bool IsRunning() {
            return this.running;
        }

        public void Start() {
            if (this.IsRunning()) {
                throw new Exception("Application is already running.");
            }

            // Load app
            this.Load();

            // Set running to true
            this.running = true;
        }

        public void Stop() {
            if (!this.IsRunning()) {
                throw new Exception("Application is not running.");
            }

            // Unload app
            this.Unload();

            this.running = false;
            System.Environment.Exit(1);
        }

    }

}
