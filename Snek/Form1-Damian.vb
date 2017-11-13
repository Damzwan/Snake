Public Class Form1

    'Declaration of Variables
    Dim delay As Integer = 200
    Dim Direction As Keys

    ' Preloads the map
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        My.Computer.Audio.Play(My.Resources.SNAKE_SOUND_EFFECT, AudioPlayMode.Background)
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
            For column = 0 To 29
                Drawbox(row, column)
            Next
        Next
    End Sub

    Public Sub Drawbox(row As Integer, column As Integer)
        Box(row, column) = New PictureBox
        ' Size of the squares
        Box(row, column).Size = New Point(25, 25)
        ' Creates a border --> Makes it look like squares
        Box(row, column).BorderStyle = BorderStyle.FixedSingle
        ' The color of the squares
        Box(row, column).BackColor = Color.LightGreen
        ' Location --> How the box is positioned 
        Box(row, column).Location = New Point(Box(row, column).Width * column, (Box(row, column).Height * row))
        ' Adds the box to the Screen
        Me.Controls.Add(Box(row, column))

    End Sub
    'Draw Upper side
    Public Sub Buildmap1()
        For column = 0 To 29
            Box(0, column).BackColor = Color.Gray
        Next
    End Sub
    'Draw lower side
    Public Sub Buildmap2()

        For columnn = 0 To 29
            Box(19, columnn).BackColor = Color.Gray
        Next
    End Sub
    'Draw Left side
    Public Sub Buildmap3()
        For row = 0 To 19
            Box(row, 0).BackColor = Color.Gray
        Next
    End Sub
    'Draw Right side
    Public Sub Buildmap4()
        For row = 0 To 19
            Box(row, 29).BackColor = Color.Gray
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

        'new state
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

    Dim Highscore As Integer = 0
    Private Sub Movement()
        Dim Score As Integer = 0

        While True
            'Tells what will happen if the user enters a certain input --> How the snake will move
            If Direction <> Nothing Then
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
                Dim nextColor = Box(nextHead.Y, nextHead.X).BackColor

                ' If you touch the side
                If nextColor = Color.Gray Then
                    MsgBox("Gray touch Red is ded")
                    Exit While
                End If
                ' If you touch yourself 
                If nextColor = Color.Red Then
                    MsgBox("Red touch Red is ded")
                    Exit While
                End If
                ' If you eat the fruit
                If nextColor = Color.Blue Then
                    Score += 10
                    AddFruit()
                Else
                    'Removes the last element from the list and colors it green again --> The snake is moving around
                    TailofSnake(Snake.Last)
                End If
                'Adds the new element to the list and colors it red --> The snake is moving around
                HeadofSnake(nextHead)
            End If


            'Allows the user to enter a delay
            System.Threading.Thread.Sleep(delay)
            Application.DoEvents()
        End While

        'The game is finished
        box_score.Text = Score
        If Score > Highscore Then
            Highscore = Score
            box_highScore.Text = Highscore
        End If
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

    Private Sub txtbox1_TextChanged(sender As Object, e As EventArgs) Handles txtbox1.TextChanged
    End Sub

    ' Het ingeven van de delay
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        delay = CInt(txtbox1.Text)
    End Sub
    'We use the start value (1, 1) so that the color remains the same
    Dim fruit As Point = New Point(1, 1)
    'Adds Fruit to the Game
    Private Sub AddFruit()
        fruit = RandomPoint()
        If Box(fruit.Y, fruit.X).BackColor = Color.Red Then
            AddFruit()
        Else
            Box(fruit.Y, fruit.X).BackColor = Color.Blue
        End If
    End Sub

    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles box_score.TextChanged
    End Sub

    Private Sub img1_Click(sender As Object, e As EventArgs) Handles img1.Click

    End Sub
End Class
