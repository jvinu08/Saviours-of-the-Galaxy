import pygame
import pgzrun
import os
import random

#Jeremiah Vinu 
#June 14, 2024
#This game is the multiplayer version of Galaga

#Center the screen
os.environ['SDL_VIDEO_CENTERED'] = '1'

#Set the application title
TITLE = 'SAVIOURS OF THE GALAXY'

#Set the height and width + colours of the screen
WIDTH = 800
HEIGHT = 600

BLACK = (0, 0, 0)
WHITE = (255, 255, 255)
RED = (255, 0, 0)
GREEN = (0, 255, 0)
BLUE = (0,255,255)

#Make lists and assign gamestate + score + timer

GameState = 0

Enemies = []
FireBullets = []
WaterBullets = []

Score = 0
TimeRemaining = 30  # Game duration in seconds

#Actors positioning

fireboy = Actor("fireboy")  
watergirl = Actor("watergirl")

fireboy.pos = 100, HEIGHT - fireboy.height
watergirl.pos = 700, HEIGHT - watergirl.height

fire_points = 0
water_points = 0

#Code for timer

def decrease_timer():
    global TimeRemaining
    global GameState
    if TimeRemaining > 0:
        TimeRemaining -= 1
        clock.schedule(decrease_timer, 1.0)  # Call this function again after 1 second
    else:
        GameState = 2  # Change the game state to "Game Over"

#Gameover
def DrawGameOver():
    screen.draw.text("Game Over", (370, 150), fontname="asteroids", fontsize=36)

#Main Menu
def DrawMenu():
    global GameState
    GameState = 0
    screen.draw.text("Welcome to SAVIOURS OF THE GALAXY", center=(WIDTH/2,150), fontname="asteroids", fontsize=36)
    screen.draw.text("Press 1 to Begin Game", (250, 300), fontname="asteroids", fontsize=36)
    screen.draw.text("Press 2 to Quit", (250, 350), fontname="asteroids", fontsize=36)
    screen.draw.text("Press 3 to see instructions", (250, 400), fontname="asteroids", fontsize=36)

# Initialize the game
def IniitalizeGame():
    global GameState
    global Score
    global TimeRemaining
    global fire_points
    global water_points

    GameState = 1
    TimeRemaining = 30  # Reset the timer to 30 seconds
    Score = 0
    fire_points = 0
    water_points = 0
    Enemies.clear()  # Clear existing enemies
    FireBullets.clear()  # Clear existing fire bullets
    WaterBullets.clear()  # Clear existing water bullets

    spawn_enemies()  # Initial spawning of enemies
    clock.schedule(decrease_timer, 1.0)  # Start the timer
    clock.schedule_interval(spawn_enemies, 2.0)  # Schedule enemy spawning every 2 seconds

#Spawn Enemies (Alien)
def spawn_enemies():
    if GameState == 1:
        for _ in range(5):
            enemy = Actor('bug')
            enemy.y = random.randint(-200, -40)
            enemy.x = random.randint(50, WIDTH - 50)
            enemy.speed = random.randint(1, 3)  # Assign each enemy a consistent, lower speed
            Enemies.append(enemy)

#Recognize Keys
def on_key_down(key):
    global GameState
    if GameState == 0:
        if key == keys.K_1:
            IniitalizeGame()
        if key == keys.K_2:
            quit()
        if key == keys.K_3:
            GameState = 3
    if GameState == 3:
        if key == keys.K_4:
            DrawMenu()
    #Bullets for Fireboy and Watergirl
    elif GameState == 1:
        if key == keys.SPACE:
            bullet = Actor('fire_bullet')  # Fireboy's bullet
            bullet._surf = pygame.transform.scale(bullet._surf, (50, 55))
            bullet.x = fireboy.x + 60
            bullet.y = fireboy.y - 40
            FireBullets.append(bullet)
        elif keyboard.up:
            bullet  = Actor('water_bullet')  # Watergirl's bullet
            bullet ._surf = pygame.transform.scale(bullet._surf, (50, 55))
            bullet.x = watergirl.x
            bullet.y = watergirl.y - 40
            WaterBullets.append(bullet)

#Background + Points + Drawing everything + instrcutions
def draw():
    global GameState
    screen.clear()
    backround = Actor('backround') 
    backround._surf = pygame.transform.scale(backround._surf, (1500, 800))
    backround._update_pos()
    backround.pos = (0, 0)
    backround.draw()

    screen.draw.text("Fire Points: " + str(fire_points), color=RED, topleft=(10, 10))       
    screen.draw.text("Water Points: " + str(water_points), color=BLUE, topright=(WIDTH - 10, 10))
    screen.draw.text(f"Time Left: {TimeRemaining} s", color=WHITE, topright=(WIDTH - 10, 30))
    

    if GameState == 0:
        DrawMenu()
    elif GameState == 1:
        fireboy.draw()
        watergirl.draw()
        for bullet in FireBullets:
            bullet.draw()
        for bullet in WaterBullets:
            bullet.draw()
        for enemy in Enemies:
            enemy.draw()
    elif GameState == 2:
        DrawGameOver()
        clock.schedule(DrawMenu, 2)
    elif GameState == 3:
            screen.draw.text("This   is   a   multiplayer   game,  Goal  is  to  get  the  highest  score", center=(WIDTH/2, HEIGHT/2 - 100), fontname="asteroids", fontsize=25)
            screen.draw.text("A   and   D   to   Move   for   P1,   Left   and   Right   Arrow   to   Move   for   P2", center=(WIDTH/2, HEIGHT/2), fontname="asteroids", fontsize=25)
            screen.draw.text("Space   to   Shoot    for   P1,   Up   Arrow   to   Shoot   for   P2", center=(WIDTH/2, HEIGHT/2 + 100), fontname="asteroids", fontsize=25)
            screen.draw.text("Goal  Score  At  top, Press   4  to  go  back  to  Menu", center=(WIDTH/2, HEIGHT/2 + 200), fontname="asteroids", fontsize=25)
            

#Update Everything + Movement keys
def update():
    global GameState
    global fireboy
    global watergirl
    global Score
    global fire_points
    global water_points
    global enemy
    if GameState == 1:
        if keyboard.left:
            watergirl.x -= 5
        if keyboard.right:
            watergirl.x += 5
        if keyboard.A:
            fireboy.x -= 5
        if keyboard.D:
            fireboy.x += 5

        #Remove bullets
        for bullet in FireBullets:
            if bullet.y < -5:
                FireBullets.remove(bullet)
            else:
                bullet.y -= 5

        for bullet in WaterBullets:
            if bullet.y < -5:
                WaterBullets.remove(bullet)
            else:
                bullet.y -= 5

        for enemy in Enemies:
            enemy.y += enemy.speed  # Use individual enemy speed
            if enemy.y > HEIGHT:
                Enemies.remove(enemy)  # Remove the enemy if it goes off-screen
                Score -= 50  # Penalty for missed enemy

            # Check collision with Fireboy's bullets
            for bullet in FireBullets:
                if enemy.colliderect(bullet):
                    fire_points += 150  # Increase Fireboy's score
                    FireBullets.remove(bullet)
                    Enemies.remove(enemy)

            # Check collision with Watergirl's bullets
            for bullet in WaterBullets:
                if enemy.colliderect(bullet):
                    water_points += 150  # Increase Watergirl's score
                    WaterBullets.remove(bullet)
                    Enemies.remove(enemy)

pgzrun.go()