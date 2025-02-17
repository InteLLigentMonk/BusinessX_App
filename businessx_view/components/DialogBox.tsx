import { DialogBoxProps } from "@/app/types/DialogBox";
import {
  Dialog,
  DialogContent,
  DialogDescription,
  DialogHeader,
  DialogTitle,
  DialogTrigger,
} from "@/components/ui/dialog";
import React, { useState } from "react";

function DialogBox({
  trigger,
  title,
  description,
  children,
  onClose,
}: DialogBoxProps) {
  const [open, setOpen] = useState(false);

  function handleOpenChange(isOpen: boolean) {
    setOpen(isOpen);
    if (!isOpen) {
      onClose();
    }
  }

  return (
    <Dialog open={open} onOpenChange={handleOpenChange}>
      <DialogTrigger>{trigger}</DialogTrigger>
      <DialogContent>
        <DialogHeader>
          <DialogTitle>{title}</DialogTitle>
          <DialogDescription>{description}</DialogDescription>
        </DialogHeader>
        {React.cloneElement(children as React.ReactElement<any>, {
          onFormSubmit: () => handleOpenChange(false),
        })}
      </DialogContent>
    </Dialog>
  );
}
export default DialogBox;
