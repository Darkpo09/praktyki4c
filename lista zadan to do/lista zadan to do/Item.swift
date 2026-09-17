//
//  Item.swift
//  lista zadan to do
//
//  Created by Weronika Kotowska on 17/09/2026.
//

import Foundation
import SwiftData

@Model
final class Item {
    var timestamp: Date
    
    init(timestamp: Date) {
        self.timestamp = timestamp
    }
}
