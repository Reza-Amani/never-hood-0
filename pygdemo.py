import pygame
from pygame.locals import *
pygame.init()

  #! /usr/bin/env python

  # Move a single pixel around the screen without crashing against the borders.

  #import pygame

  # These are used for directions.
UP = (0, -1)
DOWN = (0, 1)
LEFT = (-1, 0)
RIGHT = (1, 0)

class MovingPixel:
     """ A moving pixel class. """

     def __init__(self, x, y):
         """ Creates a moving pixel. """
         self.x = x
         self.y = y
         self.hdir = 0
         self.vdir = -1

     def direction(self, dir):
         """ Changes the pixels direction. """
         self.hdir, self.vdir = dir

     def move(self):
         """ Moves the pixel. """
         self.x += self.hdir
         self.y += self.vdir

     def draw(self, surface):
         surface.set_at((self.x, self.y), (255, 255, 255))

 # Window dimensions.
width = 640
height = 400

screen = pygame.display.set_mode((width, height))
clock = pygame.time.Clock()
running = True
pixarray = []
 # Create a moving pixel.
for x in range(1,round(height/2)-2):
    pixarray.append(MovingPixel(x, round(height/2)))
#pix = MovingPixel(round(width/2), round(height/2))

screen.fill((0, 0, 0))
while running:
 #   screen.fill((0, 0, 0))
    for pix in pixarray:
        pix.move()

        if pix.x <= 0 or pix.x >= width or pix.y <= 0 or pix.y >= height:
            print ("Crash!")
            running = False
            pix.draw(screen)

    pygame.display.flip()
    for event in pygame.event.get():
         if event.type == pygame.QUIT:
             running = False
         elif event.type == pygame.KEYDOWN:
             if event.key == pygame.K_UP:
                 for pix in pixarray:
                    pix.direction(UP)
             elif event.key == pygame.K_DOWN:
                 for pix in pixarray:
                     pix.direction(DOWN)
             elif event.key == pygame.K_LEFT:
                 for pix in pixarray:
                     pix.direction(LEFT)
             elif event.key == pygame.K_RIGHT:
                 for pix in pixarray:
                     pix.direction(RIGHT)

    pygame.display.flip()
    clock.tick(120)
