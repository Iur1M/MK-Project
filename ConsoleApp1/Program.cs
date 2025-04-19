using System.Numerics;
using Raylib_cs;


class Program
{
    public static void Main()
    {
        const int screenWidth = 1347;
        const int screenHeight = 855;
        Raylib.InitWindow(screenWidth, screenHeight, "MK");


        Raylib.InitAudioDevice();

        Music music = Raylib.LoadMusicStream("C:\\Users\\Iuko\\source\\repos\\Project\\Music.mp3");

        Texture2D background = Raylib.LoadTexture("C:\\Users\\Iuko\\source\\repos\\Project\\Map.png");

        Texture2D spriteSheetRight1 = Raylib.LoadTexture("C:\\Users\\Iuko\\source\\repos\\Project\\Walk.png");
        Texture2D spriteSheetLeft1 = Raylib.LoadTexture("C:\\Users\\Iuko\\source\\repos\\Project\\Walk-left.png");

        Texture2D spriteSheetRight2 = Raylib.LoadTexture("C:\\Users\\Iuko\\source\\repos\\Project\\Walk2.png");
        Texture2D spriteSheetLeft2 = Raylib.LoadTexture("C:\\Users\\Iuko\\source\\repos\\Project\\Walk-left2.png");

        int frameWidth = spriteSheetRight1.Width / 9;

        int frameHeight = spriteSheetRight1.Height;

        int frameWidth2 = spriteSheetRight2.Width / 9;
        int frameHeight2 = spriteSheetRight2.Height;

        float character1X = 50f;
        float character1Y = 600f;
        int frame1 = 0;
        float timer1 = 0f;
        Texture2D currentSpriteSheet1 = spriteSheetRight1;

        float character2X = 1000f;
        float character2Y = 600f;
        int frame2 = 0;
        float timer2 = 0f;
        Texture2D currentSpriteSheet2 = spriteSheetRight2;

        float frameTime = 0.1f;

        Raylib.SetTargetFPS(60);
        Raylib.PlayMusicStream(music);
        while (!Raylib.WindowShouldClose())
        {
            Raylib.UpdateMusicStream(music);
            float deltaTime = Raylib.GetFrameTime();

            timer1 += deltaTime;
            if (Raylib.IsKeyDown(KeyboardKey.D))
            {
                character1X += 3f;
                currentSpriteSheet1 = spriteSheetRight1;
                if (timer1 >= frameTime)
                {
                    frame1 = (frame1 + 1) % 9;
                    timer1 = 0f;
                }
            }
            else if (Raylib.IsKeyDown(KeyboardKey.A))
            {
                character1X -= 3f;
                currentSpriteSheet1 = spriteSheetLeft1;
                if (timer1 >= frameTime)
                {
                    frame1 = (frame1 + 1) % 9;
                    timer1 = 0f;
                }
            }
            else
            {
                frame1 = 0;
            }



            if (character1X < 0) character1X = 0;
            else if (character1X > screenWidth - frameWidth) character1X = screenWidth - frameWidth;


            timer2 += deltaTime;
            if (Raylib.IsKeyDown(KeyboardKey.Right))
            {
                character2X += 3f;
                currentSpriteSheet2 = spriteSheetRight2;
                if (timer2 >= frameTime)
                {
                    frame2 = (frame2 + 1) % 9;
                    timer2 = 0f;
                }
            }
            else if (Raylib.IsKeyDown(KeyboardKey.Left))
            {
                character2X -= 3f;
                currentSpriteSheet2 = spriteSheetLeft2;
                if (timer2 >= frameTime)
                {
                    frame2 = (frame2 + 1) % 7;
                    timer2 = 0f;
                }
            }
            else
            {
                frame2 = 0;
            }

            if (character2X < 0) character2X = 0;
            else if (character2X > screenWidth - frameWidth2) character2X = screenWidth - frameWidth2;


            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.RayWhite);
            Raylib.DrawTexture(background, 0, 0, Color.White);

            Rectangle sourceRec1 = new Rectangle(frame1 * frameWidth, 0, frameWidth, frameHeight);
            Raylib.DrawTextureRec(currentSpriteSheet1, sourceRec1, new Vector2(character1X, character1Y), Color.White);

            Rectangle sourceRec2 = new Rectangle(frame2 * frameWidth2, 0, frameWidth2, frameHeight2);
            Raylib.DrawTextureRec(currentSpriteSheet2, sourceRec2, new Vector2(character2X, character2Y), Color.White);

            Raylib.EndDrawing();
        }

        Raylib.UnloadMusicStream(music);
        Raylib.CloseAudioDevice();
        Raylib.UnloadTexture(background);
        Raylib.UnloadTexture(spriteSheetRight1);
        Raylib.UnloadTexture(spriteSheetLeft1);
        Raylib.UnloadTexture(spriteSheetRight2);
        Raylib.UnloadTexture(spriteSheetLeft2);
        Raylib.CloseWindow();
    }
}