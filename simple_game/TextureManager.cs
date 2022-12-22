using SFML.Graphics;
using SFML.Window;
class TextureManager
{
    //private static string ASSETS_PATH = "C://game/simple_game/Textures/";
    private static string ASSETS_PATH = "Textures/";
    static Texture backgroundTexture;
    static Texture headTexture;
    static Texture horizontalTexture;
    static Texture verticalTexture;
    static Texture endTexture;
    static Texture fieldTexture;
    static Texture leftUpTexture;
    static Texture rightUpTexture;
    static Texture leftDownTexture;
    static Texture rightDownTexture;
    static Texture itemTexture;
    static Texture appleTexture;
    static Texture rightPanelTexture;
    static Texture snowmanTexture;
    static Texture reindeerTexture;
    static Texture santaTexture;
    public static Texture BackgroundTexture { get {return backgroundTexture; } }
    public static Texture HeadTexture { get { return headTexture; } }
    public static Texture HorizontalTexture { get { return horizontalTexture; } }
    public static Texture VerticalTexture { get { return verticalTexture; } }
    public static Texture EndTexture { get { return endTexture; } }
    public static Texture FieldTexture { get {return fieldTexture; } }
    public static Texture LeftUpTexture { get { return leftUpTexture; } }
    public static Texture LeftDownTexture { get { return leftDownTexture; } }
    public static Texture RightUpTexture { get { return rightUpTexture; } }
    public static Texture RightDownTexture { get { return rightDownTexture; } }
    public static Texture GiftTexture { get { return itemTexture; } }
    public static Texture AppleTexture { get { return appleTexture; } }
    public static Texture RightPanelTexture { get { return rightPanelTexture; } }
    public static Texture SnowmanTexture { get { return snowmanTexture; } }
    public static Texture ReindeerTexture { get { return reindeerTexture; } }
    public static Texture SantaTexture { get { return santaTexture; } }
    public static void LoadTexture()
    {
        backgroundTexture = new Texture(ASSETS_PATH + "background.png");
        headTexture = new Texture(ASSETS_PATH + "head.png");
        horizontalTexture = new Texture(ASSETS_PATH + "horizontal.png");
        verticalTexture = new Texture(ASSETS_PATH + "vertical.png");
        endTexture = new Texture(ASSETS_PATH + "end.png");
        fieldTexture = new Texture(ASSETS_PATH + "field.png");
        leftUpTexture = new Texture(ASSETS_PATH + "leftUp.png");
        leftDownTexture = new Texture(ASSETS_PATH + "leftDown.png");
        rightUpTexture = new Texture(ASSETS_PATH + "rightUp.png");
        rightDownTexture = new Texture(ASSETS_PATH + "rightDown.png");
        itemTexture = new Texture(ASSETS_PATH + "gift.png");
        appleTexture = new Texture(ASSETS_PATH + "apple.png");
        rightPanelTexture = new Texture(ASSETS_PATH + "rightPanel.png");
        snowmanTexture = new Texture(ASSETS_PATH + "snowman.png");
        reindeerTexture = new Texture(ASSETS_PATH + "reindeer.png");
        santaTexture=new Texture(ASSETS_PATH + "santa.png");
    }  
}