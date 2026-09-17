import SwiftUI

struct Zadanie: Identifiable {
    let id = UUID()
    var nazwa: String
    var zrobione = false
}

struct ContentView: View {
    
    @State var tekst = ""
    @State var zadania: [Zadanie] = []
    
    var body: some View {
        VStack {
            
            Text("Lista rzeczy do zrobienia")
                .font(.largeTitle)
                .bold()
                .foregroundColor(.blue)
                .padding()
            
            Spacer()
            
            
            
            TextField("Wpisz zadanie...", text: $tekst)
                .textFieldStyle(.roundedBorder)
                .padding(.horizontal)
            
            Button("Dodaj") {
                if !tekst.isEmpty {
                    zadania.append(Zadanie(nazwa: tekst))
                    tekst = ""
                }
            }
            .buttonStyle(.borderedProminent)
            .tint(.blue)
            .padding()
            
            
            
            List {
                ForEach($zadania) { $zadanie in
                    HStack {
                        Button {
                            zadanie.zrobione.toggle()
                        } label: {
                            Image(systemName: zadanie.zrobione
                                  ? "checkmark.circle.fill"
                                  : "circle")
                                .foregroundColor(.blue)
                        }
                        
                        Text(zadanie.nazwa)
                            .strikethrough(zadanie.zrobione)
                    }
                }
                .onDelete { zadania.remove(atOffsets: $0) }
            }
            .frame(height: 250)
            
            
            Spacer()
        }
        
    }
}


#Preview {
    ContentView()
}
