"use client";

import { Avatar, AvatarImage } from "@/components/ui/avatar";
import { AvatarFallback } from "@radix-ui/react-avatar";
import {
  DropdownMenu,
  DropdownMenuContent,
  DropdownMenuItem,
  DropdownMenuLabel,
  DropdownMenuSeparator,
  DropdownMenuTrigger,
} from "@/components/ui/dropdown-menu";
import Image from "next/image";
import React from "react";
import { useRouter } from "next/navigation";

const NavBar = () => {
  const router = useRouter();

  return (
    <div className="w-full h-[52px] bg-white border-[1px] border-b-[#eaeaea] shadow-sm flex items-center px-4">
      <article className="flex items-center justify-between w-full">
        <section
          className="flex gap-4 items-center hover:cursor-pointer"
          onClick={() => router.push("/")}
        >
          <Image src="green-leaf-icon.svg" alt="icon" width={32} height={32} />
          <span className="font-semibold text-lg tracking-tight">
            GreenLife
          </span>
        </section>
        <section>
          <DropdownMenu>
            <DropdownMenuTrigger className="outline-none">
              <Avatar className="flex justify-center items-center hover:opacity-50">
                <AvatarImage src="https://scontent-waw2-2.xx.fbcdn.net/v/t1.6435-9/93854634_660455204768805_1014318378774429696_n.jpg?_nc_cat=100&ccb=1-7&_nc_sid=6ee11a&_nc_ohc=y8HiZuUsA60Q7kNvgGeCRMo&_nc_zt=23&_nc_ht=scontent-waw2-2.xx&_nc_gid=A8gisZn9P1ZtMPEP4IlWJsw&oh=00_AYCaq5KN0WVA7ZRE5sqpTcBMKmZnazYlsGRX1P9I7Fze8A&oe=676FED36" />
                <AvatarFallback>MP</AvatarFallback>
              </Avatar>
            </DropdownMenuTrigger>
            <DropdownMenuContent className="mr-2 w-[14rem]">
              <DropdownMenuLabel>My Account</DropdownMenuLabel>
              <DropdownMenuSeparator />
              <DropdownMenuItem>Profile</DropdownMenuItem>
              <DropdownMenuItem onClick={() => router.push("/login")}>
                Log out
              </DropdownMenuItem>
            </DropdownMenuContent>
          </DropdownMenu>
        </section>
      </article>
    </div>
  );
};

export default NavBar;
