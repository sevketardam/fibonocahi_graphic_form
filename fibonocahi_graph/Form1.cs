namespace fibonocahi_graph;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        drawSpiral();
    }

    const int SCALE = 10;
    const int OFFSET = 150;

    private void drawRectangle(Graphics g, int left, int right, int top, int bottom, int number)
    {
        Rectangle rectangle = new Rectangle(SCALE * left + OFFSET,
            SCALE * top + OFFSET,
            SCALE * (right - left),
            SCALE * (bottom - top));

        g.DrawRectangle(Pens.Red, rectangle);

        Font font = new Font("Arial", 8);
        StringFormat stringFormat = new StringFormat();
        stringFormat.Alignment = StringAlignment.Center;
        stringFormat.LineAlignment = StringAlignment.Center;
        g.DrawString(number.ToString(), font, Brushes.Black, rectangle, stringFormat);
    }

    private void drawSpiral()
    {
        if (pictureBox1.Image == null)
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        }

        using Graphics g = Graphics.FromImage(pictureBox1.Image);
        var current = 1;
        var previous = 0;

        var left = 0;
        var right = 1;
        var top = 0;
        var bottom = 0;

        const int N = 10;

        for (var i = 0; i < N; i++)
        {
            switch (i % 4)
            {
                case 0: 
                    drawRectangle(g, left, right, bottom, bottom + current, current);
                    bottom += current;
                    break;
                case 1:
                    drawRectangle(g, right, right + current, top, bottom, current);
                    right += current;
                    break;
                case 2:
                    drawRectangle(g, left, right, top - current, top, current);
                    top -= current;
                    break;
                case 3: 
                    drawRectangle(g, left - current, left, top, bottom, current);
                    left -= current;
                    break;
            }

            int temp = current;
            current += previous;
            previous = temp;
        }

        pictureBox1.Invalidate();
    }
}