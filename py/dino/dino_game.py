import pygame
import random

pygame.init()

display_width = 800
display_height =600

display = pygame.display.set_mode((display_width, display_height))
pygame.display.set_caption("DINOZAVRRRRRRRRRRRRR")

icon=pygame.image.load('istockphoto-520424758-1024x1024.jpg')
pygame.display.set_icon(icon)

usr_width = 60
usr_height = 100
usr_x = display_width / 3
usr_y = display_height - usr_height - 100

trap_width = 20
trap_height = 70
trap_x = display_width - 50
trap_y = display_height - trap_height - 100

trap_img = [pygame.image.load('E1.png'), pygame.image.load('E2.png'), pygame.image.load('E3.png')]
clock = pygame.time.Clock()

make_jump = False

jump_count = 30

class Trap:
    def __init__(self, x, y, width, height, speed, image):
        self.x = x
        self.y = y
        self.width = width
        self.height = height
        self.speed = speed
        self.image = image
    def move(self):

        if  self.x >=  self.width:
           #pygame.draw.rect(display, (224, 21, 35), (self.x, self.y, self.width, self.height))
            display.blit(self.image, (self.x, self.y))
            self.x -= self.speed
            return True
        else:
           # self.x = self.width + 50 + random.randrange(800, 1200)
             return False

    def return_self (self, rad):
        self.x = rad

def run_Game():
    global make_jump
    game = True
    trap_m = []
    create_trap_mas(trap_m)
    land = pygame.image.load(r'2.jpg')
    while game:
        for event in pygame.event.get():
            if event.type == pygame.QUIT:
                pygame.quit()
                quit()
        keys = pygame.key.get_pressed()
        if keys[pygame.K_SPACE]:
            make_jump = True
        if make_jump:
            jump()
        #display.fill((255, 255, 255))
        display.blit(land, (0, 50))
        draw_mas(trap_m)

        pygame.draw.rect(display, (100, 100, 100), (usr_x, usr_y, usr_width, usr_height))
        pygame.display.update()
        clock.tick(120)
def jump() :
    global usr_y, jump_count, make_jump
    if jump_count >= -30:
        usr_y -= jump_count / 1.5
        jump_count -= 1
    else:
        jump_count = 30
        make_jump = False

# def draw_trap():
#     global trap_x, trap_y, trap_height, trap_width
#     if trap_x >= -trap_width:
#         pygame.draw.rect(display,(224,21,35),(trap_x, trap_y, trap_width, trap_height))
#         trap_x -= 7
#     else:
#         trap_x = display_width - 50
def create_trap_mas(mas):
    mas.append(Trap(display_width - 50, display_height-150, 20, 70, 6, trap_img[0]))
    mas.append(Trap(display_width + 150, display_height-150, 30, 50, 6, trap_img[1]))
    mas.append(Trap(display_width + 600, display_height-150, 25, 80, 6, trap_img[2]))


def find_rad(mas):
    max1 = max(mas[0].x, mas[1].x, mas[2].x)

    if max1 < display_width:
        rad = display_width
        if rad - max1 < 80:
            rad += 190
    else:
        rad = max1
    choice = random.randrange(0, 5)
    if choice == 0:
        rad += random.randrange(5, 10)
    else:
        rad += random.randrange(300, 450)
    return rad

def draw_mas(mas):
    for Trap in mas:
        check = Trap.move()
        if not check:
            rad = find_rad(mas)
            Trap.return_self(rad)





run_Game()