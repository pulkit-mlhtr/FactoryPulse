# Factory Equipment Dashboard

## Overview

The **Factory Equipment Dashboard** is a **real-time web application** built with **ASP.NET Core**, **SignalR**, **PostgreSQL**, and **React + TypeScript + TailwindCSS**. It simulates a factory monitoring system where users can track and manage equipment across production lines.

The project is structured to be **modular, scalable, and maintainable**, with a focus on real-time updates and role-based views.

---

## Features

### Real-Time Equipment Monitoring

- Live updates of equipment states using **SignalR**.
- Automatic UI refresh on state changes.
- Stores equipment state history for auditing.

### Role-Based Tabs

1. **Worker Tab**
   - Fixed to a single factory (hard-coded Factory ID: 101).
   - Can perform **equipment state changes** (Red, Yellow, Green).
   - Simple UI for frontline operators.

2. **Supervisor Tab**
   - Can **select any factory** from a dropdown.
   - Can **view equipment list**, **current state**, and **history logs**.
   - Provides detailed insights for supervisory roles.

### Equipment History

- Maintains a **time-series log of state changes**.
- View history in a **modal with table or timeline**.
- Will support **audit and reporting** future requirements.

### Modular Frontend

- **Components**: `EquipmentCard`, `EquipmentGrid`, `FactorySelector`, `EquipmentHistoryModal`, `Tabs`.
- **Hooks**: `useSignalR` for live updates.
- **Separation of concerns** for easier maintenance and extension.
