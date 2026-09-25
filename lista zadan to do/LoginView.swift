
import SwiftUI
import FirebaseAuth

struct LoginView: View {

    @State var email = ""
    @State var haslo = ""
    @State var zalogowany = false

    var body: some View {

        if zalogowany {
            ContentView()
        } else {
            VStack(spacing: 20) {

                Text("Zaloguj się")
                    .font(.largeTitle)
                    .bold()
                    .foregroundColor(.blue)

                TextField("Email", text: $email)
                    .textFieldStyle(.roundedBorder)

                SecureField("Hasło", text: $haslo)
                    .textFieldStyle(.roundedBorder)

                Button("Zaloguj") {
                    Auth.auth().signIn(
                        withEmail: email,
                        password: haslo
                    ) { _, error in
                        if error == nil {
                            zalogowany = true
                        }
                    }
                }
                .buttonStyle(.borderedProminent)

                Button("Zarejestruj się") {
                    Auth.auth().createUser(
                        withEmail: email,
                        password: haslo
                    ) { _, error in
                        if error == nil {
                            zalogowany = true
                        }
                    }
                }
            }
            .padding(40)
            .background(
                Color.blue.opacity(0.1)
                    .ignoresSafeArea()
            )
        }
    }
}//
//  LoginView.swift
//  lista zadan to do
//
//  Created by Weronika Kotowska on 24/09/2026.
//

