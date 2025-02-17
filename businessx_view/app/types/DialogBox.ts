export type DialogBoxProps = {
  trigger: React.ReactNode;
  title?: string;
  description?: string;
  children?: React.ReactNode;
  onClose: () => void;
};
