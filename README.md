# 🔫 BulletHell Top-Down

> Một tựa game 2D top-down bullet hell được xây dựng bằng **Unity 6000.5.1f1** với Universal Render Pipeline (URP).

[![Unity](https://img.shields.io/badge/Unity-6000.5.1f1-black?logo=unity)](https://unity.com/)
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)

---

## 🎮 Tổng quan

BulletHell Top-Down là một game hành động góc nhìn từ trên xuống (top-down), nơi người chơi chiến đấu qua các phòng dungeon được sinh ngẫu nhiên theo cơ chế procedural. Game lấy cảm hứng từ các tựa game bullet hell/roguelike nổi tiếng với hệ thống né đòn (dodge roll), bắn súng đa hướng theo chuột, và hệ thống máu hiển thị trực quan bằng trái tim.

---

## ✨ Tính năng chính

- **🎯 Điều khiển nhân vật linh hoạt**
  - Di chuyển bằng phím **WASD**.
  - Lộn nhào (Dodge Roll) bằng phím **Space** — bất tử trong lúc lộn, có cooldown.
  - Lật mặt nhân vật theo hướng di chuyển.

- **🔫 Hệ thống vũ khí**
  - Súng xoay theo hướng chuột (360°).
  - Bắn bằng chuột trái với fire rate tùy chỉnh.
  - Sử dụng **Object Pooling** để tối ưu hiệu năng đạn.

- **❤️ Hệ thống máu**
  - Hiển thị máu bằng giao diện trái tim (tim đầy / tim rỗng).
  - Có thể tăng máu tối đa, hồi máu, nhận sát thương.
  - Sự kiện `OnHealthChanged` để UI tự động cập nhật.

- **🏰 Sinh dungeon ngẫu nhiên (Procedural Generation)**
  - Phòng bắt đầu → Các phòng Combat/Utility được xáo trộn ngẫu nhiên → Phòng Boss.
  - Căn chỉnh entrance/exit tự động giữa các phòng.
  - Không có 2 phòng Utility đứng cạnh nhau (thuật toán `FixAdjacentUtilities`).

- **👾 Kẻ thù**
  - `StrikeDummy`: Kẻ thù tuần tra giữa 2 điểm, khi trúng đạn sẽ bị stun (hitstun) kèm animation `Hit`.

- **🌍 Chuyển cảnh**
  - `TransitionManager`: Singleton quản lý chuyển cảnh mượt với hiệu ứng fade.
  - `Turtorial`: Chuyển cảnh khi người chơi chạm vào trigger.

- **📋 Tương tác**
  - `SignInteract`: Bảng chỉ dẫn — nhấn **E** để đọc, tự ẩn khi rời vùng.

- **✨ Hiệu ứng văn bản**
  - `Subtitle`: Animation sóng sin phóng to/thu nhỏ chữ liên tục.

---

## 🗂️ Cấu trúc dự án

```
Assets/
├── Animation/                  # Asset animation
├── Asset/                      # Sprite, texture, material
├── Prefabs/                    # Prefab (Player, Enemy, Bullet, Room...)
├── Scenes/                     # Các scene game
├── Scripts/
│   ├── Enemy/
│   │   ├── BulletTurtorial/    # Đạn tutorial cho enemy
│   │   └── Dummy/              # Kẻ thù cơ bản (StrikeDummy)
│   ├── Player/
│   │   ├── Bullet.cs           # Logic viên đạn
│   │   ├── BulletPool.cs       # Object pool quản lý đạn
│   │   ├── HealthUI.cs         # UI hiển thị máu (trái tim)
│   │   ├── PlayerController.cs # Điều khiển nhân vật
│   │   ├── PlayerHealth.cs     # Hệ thống máu người chơi
│   │   └── WeaponController.cs # Điều khiển súng
│   ├── RoomGeneration/
│   │   ├── DungeonGenerator.cs # Sinh dungeon ngẫu nhiên
│   │   └── RoomInfo.cs         # Thông tin phòng (entrance/exit/spawn)
│   ├── Scene Transition/
│   │   ├── SceneTransition.cs  # Load scene đơn giản
│   │   ├── Transition.cs       # Load scene qua OnClick
│   │   ├── TransitionManager.cs# Singleton chuyển cảnh + fade
│   │   └── Turtorial.cs        # Chuyển cảnh qua trigger
│   ├── Text Animation/
│   │   └── Subtitle.cs         # Hiệu ứng sóng cho text
│   └── Turtorial/
│       └── SignInteract.cs     # Tương tác bảng chỉ dẫn
├── Settings/                   # Cấu hình Render Pipeline, Input
├── Simple Scene Fade Load System/  # Hệ thống fade mượt
├── TextMesh Pro/               # TextMesh Pro assets
└── Tilemap/                    # Tilemap cho dungeon
```

---

## 🚀 Cài đặt & Chạy

### Yêu cầu
- **Unity 6000.5.1f1** trở lên
- **.NET** được cài đặt kèm Unity Editor

### Các bước
1. **Clone repository:**
   ```bash
   git clone https://github.com/Duckcode-source/BulletHell.git
   ```
2. **Mở dự án** trong Unity Hub bằng cách chọn thư mục `BulletHellTopDown`.
3. **Mở scene chính** trong `Assets/Scenes/` và nhấn **Play** để chạy game.

---

## 🎮 Cách chơi

| Phím / Thao tác | Hành động |
|----------------|-----------|
| **W, A, S, D** | Di chuyển nhân vật |
| **Chuột** | Ngắm hướng bắn |
| **Chuột trái** | Bắn |
| **Space** | Lộn nhào (Dodge Roll) |
| **E** | Tương tác với bảng chỉ dẫn |

---

## 🔧 Công nghệ sử dụng

| Công nghệ | Mục đích |
|----------|----------|
| **Unity 6000** | Game engine |
| **Universal Render Pipeline (URP)** | Đồ họa 2D chất lượng cao |
| **Cinemachine** | Camera động |
| **Input System** | Xử lý input đa nền tảng |
| **Unity Object Pool** | Tối ưu hiệu năng đạn |
| **TextMesh Pro** | Văn bản chất lượng cao |
| **2D Tilemap + SpriteShape** | Thiết kế level |

---

## 📝 Ghi chú phát triển

- Game đang trong giai đoạn phát triển ban đầu. Nhiều tính năng còn đang được hoàn thiện.
- Các script được viết với comment chi tiết bằng tiếng Việt để dễ dàng học tập và bảo trì.
- Hệ thống dungeon generator hiện tại sinh tuyến tính (linear) — có thể mở rộng thành đồ thị (graph-based) trong tương lai.

---




*Made with ❤️ and Unity*
