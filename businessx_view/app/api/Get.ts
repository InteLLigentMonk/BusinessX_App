export const getAll = async (
  endpoint: string,
  setState: React.Dispatch<React.SetStateAction<any>>
) => {
  const baseUrl = "https://localhost:7036/api/";
  const url = new URL(endpoint, baseUrl);

  try {
    const response = await fetch(url.toString());
    if (!response.ok) {
      throw new Error("Network response was not ok");
    }
    const data = await response.json();
    setState(data);
  } catch (error) {
    console.error(`Error fetching data from ${url.toString()}:`, error);
  }
};

export const getOneById = async (endpoint: string, projectId: string) => {
  const baseUrl = "https://localhost:7036/api/";
  const url = new URL(`${endpoint}/${projectId}`, baseUrl);

  try {
    const response = await fetch(url.toString());
    if (!response.ok) {
      throw new Error(`HTTP error! status: ${response.status}`);
    }
    const data = await response.json();
    return data;
  } catch (error) {
    console.error(`Error fetching project data from ${url.toString()}:`, error);
    throw error;
  }
};
