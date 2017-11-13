Public Class Snek

    'Declaration of Variables
    Dim delay As Integer = 200
    Dim Direction As Keys

    ' Preloads the map
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Buildmap()
        Buildmap1()
        Buildmap2()
        Buildmap3()
        Buildmap4()

        Me.Show()

    End Sub

    Dim Box(19, 29) As PictureBox

    ' The creation of the map with the for loop --> So for the first row it'll draw 30 horizontal boxes then it goes to the next row etc...
    Public Sub Buildmap()
        For row = 0 To 19
            For colum = 0 To 29
                Drawbox(row, colum)
            Next
        Next
    End Sub

    Public Sub Drawbox(row As Integer, colum As Integer)
        Box(row, colum) = New PictureBox
        ' Size of the squares
        Box(row, colum).Size = New Point(25, 25)
        ' Creates a border --> Makes it look like squares
        Box(row, colum).BorderStyle = BorderStyle.FixedSingle
        ' The color of the squares
        Box(row, colum).BackColor = Color.LightGreen
        ' Location --> How the box is positioned 
        Box(row, colum).Location = New Point(Box(row, colum).Width * colum, (Box(row, colum).Height * row))
        ' Adds the box to the Screen
        Me.Controls.Add(Box(row, colum))

    End Sub
    'Draw Upper side
    Public Sub Buildmap1()
        Dim row = 0
        For colum = 0 To 29
            Box(row, colum).BackColor = Color.Gray
        Next
    End Sub
    'Draw lower side
    Public Sub Buildmap2()
        Dim row = 19
        For colum = 0 To 29
            Box(row, colum).BackColor = Color.Gray
        Next
    End Sub
    'Draw Left side
    Public Sub Buildmap3()
        For row = 0 To 19
            Dim colum = 0
            Box(row, colum).BackColor = Color.Gray
        Next
    End Sub
    'Draw Right side
    Public Sub Buildmap4()
        For row = 0 To 19
            Dim colum = 29
            Box(row, colum).BackColor = Color.Gray
        Next
    End Sub

    ' The exit button
    Private Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        Me.Close()
    End Sub

    ' The creation of a random point in the field
    Dim rnd As System.Random = New Random()
    Public Function RandomPoint()
        Return New Point(rnd.Next(1, Box.GetLength(1) - 1), rnd.Next(1, Box.GetLength(0) - 1))
    End Function

    'The creation of an empty list to remember the size of the snake
    Dim Snake As List(Of Point) = New List(Of Point)

    Private Sub Newgame(sender As Object, e As EventArgs) Handles Button1.Click
        'clear previous game
        For Each part In Snake
            Box(part.Y, part.X).BackColor = Color.LightGreen
        Next
        Snake.Clear()
        'We use this to remove the last input so that it start with no input
        Direction = Keys.None
        'Adds a Fruit to the game
        Box(fruit.Y, fruit.X).BackColor = Color.LightGreen

        'New state
        'Creates a random fruit on the field
        AddFruit()
        'Spawns the snake on the field
        HeadofSnake(RandomPoint())
        'Allows the snake to move 
        Movement()
    End Sub

    ' Adds a certain point to the list and colors it red(the color of the snake) --> Adds a bodypart to the snake
    Private Sub HeadofSnake(ptn As Point)
        Snake.Insert(0, ptn)
        Box(ptn.Y, ptn.X).BackColor = Color.Red
    End Sub

    'Removes the last element of the snake and colors it green(The color of the field) again
    Private Sub TailofSnake(ptn As Point)
        Snake.Remove(ptn)
        Box(ptn.Y, ptn.X).BackColor = Color.LightGreen
    End Sub

    'Start highscore = 0
    Dim highScore As Integer = 0

    Private Sub Movement()
        Dim Score As Integer = 0
        'Tells what will happen if the user enters a certain input --> How the snake will move
        While True
            Dim delta As Point
            Select Case Direction
                Case Keys.Right
                    delta = New Point(1, 0)
                Case Keys.Left
                    delta = New Point(-1, 0)
                Case Keys.Up
                    delta = New Point(0, -1)
                Case Keys.Down
                    delta = New Point(0, 1)
            End Select
            'Adds the value to the first element(The head) of the snake so that it moves
            Dim nextHead As Point = Snake.First + delta
            'When the snake touches the borders the game will end and when it touches the fruit another one spawns/Score will be added by 10
            If Box(nextHead.Y, nextHead.X).BackColor = Color.Gray Then Exit While
            'At the start of the game there is no movement, the code written below would cause the game to be over as soon as you press 'New Game'. So thats why we use 'If Not' in this case 
            If Not nextHead = Snake.First Then
                If Box(nextHead.Y, nextHead.X).BackColor = Color.Red Then Exit While
            End If
            If Box(nextHead.Y, nextHead.X).BackColor = Color.Blue Then
                Score += 10
                AddFruit()
            Else
                'Removes the last element from the list and colors it green again --> The snake is moving around
                TailofSnake(Snake.Last)
            End If
            'Adds the new element to the list and colors it red --> The snake is moving around
            HeadofSnake(nextHead)
            'Allows the user to enter a delay
            System.Threading.Thread.Sleep(delay)
            Application.DoEvents()
        End While

        'The game is finished
        box_score.Text = Score
        If Score >= highScore Then
            highScore = Score
            box_highScore.Text = highScore
        End If
        MsgBox("Game Over")
    End Sub

    'Checks whether the direction is up, down left or right and stores it into a variable to remember which key was last pressed
    'It also checks whether the new input is the opposite of the other(left, right) and (up, down), if this is the case the new input will be seen as invalid
    Private Sub Form1_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Then
            If Direction = Keys.Up And e.KeyCode = Keys.Down Then Exit Sub
            If Direction = Keys.Down And e.KeyCode = Keys.Up Then Exit Sub
            If Direction = Keys.Left And e.KeyCode = Keys.Right Then Exit Sub
            If Direction = Keys.Right And e.KeyCode = Keys.Left Then Exit Sub
            Direction = e.KeyCode
        End If
    End Sub

    Private Sub txtbox1_TextChanged(sender As Object, e As EventArgs) Handles delay_box.TextChanged
    End Sub

    'userInput of the delay
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        delay = CInt(delay_box.Text)
    End Sub
    'We use the start value (1, 1) so that the color remains the same
    Dim fruit As Point = New Point(1, 1)
    'Adds Fruit to the Game
    Private Sub AddFruit()
        fruit = RandomPoint()
        'If the random point is Already colored red place it on another random location(recursion)
        If Box(fruit.Y, fruit.X).BackColor = Color.Red Then AddFruit()
        ' Color the random point Blue 
        Box(fruit.Y, fruit.X).BackColor = Color.Blue
    End Sub

    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles box_score.TextChanged
    End Sub

    Private Sub box_score_TextChanged(sender As Object, e As EventArgs) Handles box_score.TextChanged

    End Sub
End Class
