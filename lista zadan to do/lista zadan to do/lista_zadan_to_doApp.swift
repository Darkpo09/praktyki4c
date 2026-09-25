
import SwiftUI
import FirebaseCore

@main
struct lista_zadan_to_doApp: App {
    
    init() {
        FirebaseApp.configure()
    }
    
    var body: some Scene {
        WindowGroup {
            ContentView()
        }
    }
}
