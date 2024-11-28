"use client";

import { DogIcon } from "lucide-react";
import "mapbox-gl/dist/mapbox-gl.css";
import { useMemo, useState } from "react";
import Map, { type MapMouseEvent, Marker, Popup } from "react-map-gl";

const places = [
  {
    id: 1,
    longitude: 18.6466,
    latitude: 54.352,
  },
  {
    id: 2,
    longitude: 18.6466,
    latitude: 54.052,
  },
  {
    id: 3,
    longitude: 18.9466,
    latitude: 54.352,
  },
  {
    id: 4,
    longitude: 18.9466,
    latitude: 54.052,
  },
];

export default function Home() {
  const markers = useMemo(
    () =>
      places.map((place) => (
        <Marker
          key={place.id}
          longitude={place.longitude}
          latitude={place.latitude}
        >
          <DogIcon />
        </Marker>
      )),
    [places]
  );
  const [showPopup, setShowPopup] = useState<boolean>(true);

  const mapClicked = (e: MapMouseEvent) => {
    console.log(e);
  };

  return (
    <div className="w-full h-full flex justify-center items-center mt-[3rem]">
      <div className="w-full h-full flex justify-center items-center">
        <Map
          onClick={(e) => mapClicked(e)}
          reuseMaps
          mapboxAccessToken={process.env.NEXT_PUBLIC_MAP_API}
          initialViewState={{
            longitude: 18.6466,
            latitude: 54.352,
            zoom: 10,
          }}
          style={{
            height: "80vh",
            width: "80%",
            aspectRatio: 16 / 9,
            borderRadius: "10px",
          }}
          mapStyle="mapbox://styles/mapbox/streets-v9"
        >
          {showPopup && (
            <Popup longitude={18.6466} latitude={54.352} anchor="bottom">
              You are here
            </Popup>
          )}

          {markers}
        </Map>
        {/* <div className="h-[80vh] aspect-video rounded-[10px] bg-green-500"></div> */}
      </div>
    </div>
  );
}
