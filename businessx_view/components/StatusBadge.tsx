export default function StatusBadge(status: string) {
  return (
    <span
      className={`px-2 py-1 rounded-full text-xs font-medium border-2 ${
        status === "Skapad"
          ? " text-orange-400 border-orange-400"
          : status === "Pågående"
          ? "text-blue-400 border-blue-400"
          : status === "Försenad"
          ? "text-red-400 border-red-400"
          : "text-green-400 border-green-400"
      }`}
    >
      {status}
    </span>
  );
}
